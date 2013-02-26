using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolvisSC2Viewer {
    public interface ICalculator {
        bool HasFormulaSolarVSG { get; }
        bool HasFormulaSolarKW { get; }
        double Formula1(RowValues rowValues, SeriesState state);
        double Formula2(RowValues rowValues, SeriesState state);
        double Formula3(RowValues rowValues, SeriesState state);
        double Formula4(RowValues rowValues, SeriesState state);
        double Formula5(RowValues rowValues, SeriesState state);

        double FormulaSolarVSG(RowValues rowValues);
        double FormulaSolarKW(RowValues rowValues);
    }
}
