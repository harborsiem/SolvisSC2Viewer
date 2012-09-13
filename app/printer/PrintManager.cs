using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;

namespace SolvisSC2Viewer {
    internal class PrintManager : IDisposable {
        private const string Tab10 = "          ";

        private static Font boldFont = new Font("Courier New", 9.0f, FontStyle.Bold);
        private static Font regularFont = new Font("Courier New", 9.0f, FontStyle.Regular);
        private static readonly int PrintHeaderHeight = boldFont.Height * 5 + regularFont.Height * 2;
        private static readonly int PrintTitleHeight = boldFont.Height + regularFont.Height;
        private static readonly int PrintRowHeight = regularFont.Height + 3;
        private static int rowsFirstPage;
        private static int rowsNextPages;

        private Rectangle printArea;
        private StringFormat format;
        private int page;
        private int maxPages;
        private int listIndex;
        private StringBuilder builder = new StringBuilder(120);
        private PrintDocument printDocument;
        private string parameterFileName;
        private DateTime parameterFileDate;
        private IList<PrintProperty> parameterList;
        private string printTitle;
        private Pen pen;
        private bool disposed;

        public PrintManager() {
        }

        public void PrintParameters(IList<PrintProperty> list, DateTime fileDate) {
            PageSettings pageSettings = new PageSettings();
            pageSettings.Margins = new Margins(78, 59, 59, 59); //(20, 15, 15, 15)mm
            pageSettings.Landscape = false;
            printDocument = new PrintDocument();
            printDocument.BeginPrint += BeginPrint;
            printDocument.PrintPage += PrintAll;
            printDocument.EndPrint += EndPrint;
            printDocument.DefaultPageSettings = pageSettings;
            parameterFileName = "paramact.txt";
            this.parameterFileDate = fileDate;
            parameterList = list;
            printTitle = "Parameter";
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    if (format != null) {
                        format.Dispose();
                    }
                    if (printDocument != null) {
                        printDocument.Dispose();
                    }
                    if (boldFont != null) {
                        boldFont.Dispose();
                    }
                    if (regularFont != null) {
                        regularFont.Dispose();
                    }
                    if (pen != null) {
                        pen.Dispose();
                    }
                }
                disposed = true;
            }
        }

        public PrintDocument PrintDocument {
            get { return printDocument; }
        }

        private void BeginPrint(object sender, PrintEventArgs e) {
            pen = new Pen(Color.Black);
            page = 0;
            listIndex = 0;
        }

        private void EndPrint(object sender, PrintEventArgs e) {
            pen.Dispose();
        }

        private void PrintAll(object sender, PrintPageEventArgs e) {
            int paHeight;
            int paWidth;
            int hardX;
            int hardY;
            if (PrintDocument.PrintController.IsPreview) {
                hardX = 0;
                hardY = 0;
            } else {
                hardX = (int)e.PageSettings.HardMarginX;
                hardY = (int)e.PageSettings.HardMarginY;
            }
            format = new StringFormat(StringFormatFlags.LineLimit);
            printArea = new Rectangle();
            Margins margins = e.PageSettings.Margins;
            PaperSize paperSize = e.PageSettings.PaperSize;
            printArea.X = margins.Left - hardX;
            printArea.Y = margins.Top - hardY;
            paHeight = paperSize.Height - margins.Top - margins.Bottom;
            paWidth = paperSize.Width - margins.Left - margins.Right;
            printArea.Width = paWidth;
            printArea.Height = paHeight;
            int lastRowY = printArea.Height + margins.Top - hardY - boldFont.Height * 2;
            int rows = 0;

            if (page == 0) {
                maxPages = GetMaxPages(printArea.Y, lastRowY);
                PrintHeader(e.Graphics);
            }
            PrintTitle(e.Graphics);
            for (int i = listIndex; i < parameterList.Count; i++) {
                PrintRow(e.Graphics, i);
                rows++;
                listIndex++;
                if (page == 0) {
                    if (rows >= rowsFirstPage) {
                        break;
                    }
                } else {
                    if (rows >= rowsNextPages) {
                        break;
                    }
                }
            }
            printArea.Y = printArea.Height + margins.Top - hardY + boldFont.Height;
            PrintTrailer(e.Graphics, page + 1, maxPages);
            page++;
            if (listIndex >= parameterList.Count) {
                e.HasMorePages = false;
                page = 0;
            } else {
                e.HasMorePages = true;
            }
        }

        private int GetMaxPages(int firstY, int lastRowY) {
            int pages = 1;
            int count = parameterList.Count;
            rowsFirstPage = (int)Math.Round((double)(lastRowY - firstY - PrintHeaderHeight - PrintTitleHeight) / (double)PrintRowHeight);
            count -= rowsFirstPage;
            if (count > 0) {
                rowsNextPages = (int)Math.Round((double)(lastRowY - firstY - PrintTitleHeight) / (double)PrintRowHeight);
                pages += (int)Math.Ceiling((double)count / (double)rowsNextPages);
            }
            return pages;
        }

        private void PrintHeader(Graphics graphics) {
            DateTime fileDate = this.parameterFileDate;
            graphics.DrawString("*************************************************************************************",
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;

            graphics.DrawString("** File : " + parameterFileName,
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;

            graphics.DrawString("**                                                                                 **",
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;

            graphics.DrawString("** Date : " + fileDate.ToShortDateString() + "        Time : " + fileDate.ToLongTimeString(),
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;

            graphics.DrawString("*************************************************************************************",
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;
            printArea.Y += regularFont.Height * 2; //2 LeerZeilen
        }

        private void PrintTitle(Graphics graphics) {
            graphics.DrawString(printTitle,
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;

            graphics.DrawString("-------------------------------------------------------------------------------------",
                regularFont, Brushes.Black, printArea, format);
            printArea.Y += regularFont.Height;
        }

        private void PrintTrailer(Graphics graphics, int pageCount, int maxPage) {
            graphics.DrawString(Tab10 + Tab10 + Tab10 + "- " + pageCount.ToString(CultureInfo.InvariantCulture) + " / " + maxPage.ToString(CultureInfo.InvariantCulture) + " -",
                boldFont, Brushes.Black, printArea, format);
            printArea.Y += boldFont.Height;
        }

        private void PrintRow(Graphics graphics, int index) {
            PrintProperty selected = parameterList[index];
            builder.Length = 0;
            builder.Append(selected.DisplayName);
            for (int i = selected.DisplayName.Length; i < 64; i++) {
                builder.Append(' ');
            }
            //builder.Append(selected.Category);
            //for (int i = selected.Category.Length; i < 10; i++) {
            //    builder.Append(' ');
            //}
            //builder.Append(selected.HeatingUser);
            //for (int i = selected.HeatingUser.Length; i < 34; i++) {
            //    builder.Append(' ');
            //}
            //builder.Append(selected.PrintCategory.ToString());
            //for (int i = selected.PrintCategory.ToString().Length; i < 26; i++) {
            //    builder.Append(' ');
            //}
            builder.Append(selected.ValueString);
            graphics.DrawString(builder.ToString(),
                regularFont, Brushes.Black, printArea, format);
            printArea.Y += regularFont.Height + 3;
            graphics.DrawLine(pen, printArea.X, printArea.Y - 2, printArea.X + printArea.Width, printArea.Y - 2);
            Size size = TextRenderer.MeasureText(Tab10, regularFont);
            int x = printArea.X + (int)(size.Width * 6.4f);
            int y = printArea.Y - 3 - regularFont.Height;
            graphics.DrawLine(pen, x, y, x, printArea.Y);
        }
    }
}
