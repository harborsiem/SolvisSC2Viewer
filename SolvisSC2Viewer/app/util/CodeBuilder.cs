//#define Store

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Globalization;
using SolvisSC2Viewer.Properties;

namespace SolvisSC2Viewer {
    internal class CodeBuilder {
        private string txtCompile;

        private StringBuilder _source = new StringBuilder();

        public void Calculate(Dictionary<FreeFormulas, string> formulas) {
            // Blank out result fields and compile result fields
            InitializeFields();

            // build the class using codedom
            BuildClass(formulas);

#if Store
            FileStream stream = File.Create(ConfigManager.ConfigDir + Path.DirectorySeparatorChar + "Calculator.cs");
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(_source.ToString());
            writer.Close();
#endif

            // compile the class into an in-memory assembly.
            // if it doesn't compile, show errors in the window
            CompilerResults results = CompileAssembly();

            // if the code compiled okay,
            // run the code using the new assembly (which is inside the results)
            if (results != null && results.CompiledAssembly != null) {
                // run the evaluation function
                RunCode(results);
            } else {
                CalculatorProxy.Calculator = null;
            }
        }

        private void InitializeFields() {
            //txtResult = "";
            txtCompile = "";
        }

        /// <summary>
        /// Main driving routine for building a class
        /// </summary>
        private void BuildClass(Dictionary<FreeFormulas, string> formulas) {
            // need a string to put the code into
            _source = new StringBuilder();
            StringWriter sw = new StringWriter(_source, CultureInfo.InvariantCulture);

            //Declare your provider and generator
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeGenerator generator = codeProvider.CreateGenerator(sw);
            CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

            CodeNamespace myNamespace = new CodeNamespace("SolvisSC2Viewer");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

            //Build the class declaration and member variables			
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
            classDeclaration.BaseTypes.Add(typeof(ICalculator));
            classDeclaration.IsClass = true;
            classDeclaration.Name = "Calculator";
            classDeclaration.Attributes = MemberAttributes.Public;

            BuildFields(classDeclaration);

            CodeConstructor defaultConstructor = BuildConstructor(classDeclaration);

            CodeMemberProperty hasFormulaSolarVSG = MakeProperty("HasFormulaSolarVSG", "hasFormulaSolarVSG", typeof(bool));
            classDeclaration.Members.Add(hasFormulaSolarVSG);
            CodeMemberProperty hasFormulaSolarKW = MakeProperty("HasFormulaSolarKW", "hasFormulaSolarKW", typeof(bool));
            classDeclaration.Members.Add(hasFormulaSolarKW);
            //Formula1 Method
            classDeclaration.Members.Add(BuildUserFormula("Formula1", GetFormula(formulas, FreeFormulas.Formula1)));
            //Formula2 Method
            classDeclaration.Members.Add(BuildUserFormula("Formula2", GetFormula(formulas, FreeFormulas.Formula2)));
            //Formula3 Method
            classDeclaration.Members.Add(BuildUserFormula("Formula3", GetFormula(formulas, FreeFormulas.Formula3)));
            //Formula4 Method
            classDeclaration.Members.Add(BuildUserFormula("Formula4", GetFormula(formulas, FreeFormulas.Formula4)));
            //Formula5 Method
            classDeclaration.Members.Add(BuildUserFormula("Formula5", GetFormula(formulas, FreeFormulas.Formula5)));

            string formula;
            formula = GetFormula(formulas, FreeFormulas.SolarVSG);
            string boolExpression = string.IsNullOrWhiteSpace(formula) ? "false" : "true";
            defaultConstructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("hasFormulaSolarVSG"), new CodeSnippetExpression(boolExpression)));
            classDeclaration.Members.Add(BuildSolarFormula("FormulaSolarVSG", formula));

            formula = GetFormula(formulas, FreeFormulas.SolarKW);
            boolExpression = string.IsNullOrWhiteSpace(formula) ? "false" : "true";
            defaultConstructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("hasFormulaSolarKW"), new CodeSnippetExpression(boolExpression)));

            classDeclaration.Members.Add(BuildSolarFormula("FormulaSolarKW", formula));

            //write code
            myNamespace.Types.Add(classDeclaration);
            generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
            sw.Flush();
            sw.Close();
        }

        private static string GetFormula(Dictionary<FreeFormulas, string> formulas, FreeFormulas ident) {
            string formula;
            if (formulas.ContainsKey(ident)) {
                formula = formulas[ident];
            } else {
                formula = null;
            }
            return formula;
        }

        private static void BuildFields(CodeTypeDeclaration classDeclaration) {
            classDeclaration.Members.Add(FieldVariable("hasFormulaSolarVSG", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("hasFormulaSolarKW", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal1", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal2", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal3", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal4", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal5", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal1", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal2", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal3", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal4", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal5", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal6", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal7", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal8", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal9", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal10", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal1", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal2", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal3", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal4", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal5", typeof(int), MemberAttributes.Private));
        }

        private static CodeConstructor BuildConstructor(CodeTypeDeclaration classDeclaration) {
            CodeConstructor defaultConstructor = new CodeConstructor();
            defaultConstructor.Attributes = MemberAttributes.Public;
            defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
            classDeclaration.Members.Add(defaultConstructor);
            return defaultConstructor;
        }

        private static CodeMemberMethod BuildUserFormula(string name, string formula) {
            CodeMemberMethod calculate = new CodeMemberMethod();
            calculate.Name = name;
            calculate.ReturnType = new CodeTypeReference(typeof(double));
            calculate.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RowValues), "rowValues"));
            calculate.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SeriesState), "state"));
            calculate.Comments.Add(new CodeCommentStatement("Calculate an " + name, true));
            calculate.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (string.IsNullOrWhiteSpace(formula)) {
                formula = "return 0.0";
            }
            calculate.Statements.Add(new CodeExpressionStatement(new CodeSnippetExpression(formula)));
            return calculate;
        }

        private static CodeMemberMethod BuildSolarFormula(string name, string formula) {
            CodeMemberMethod calculate = new CodeMemberMethod();
            calculate.Name = name;
            calculate.ReturnType = new CodeTypeReference(typeof(double));
            calculate.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RowValues), "rowValues"));
            calculate.Comments.Add(new CodeCommentStatement("Calculate an " + name, true));
            calculate.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (string.IsNullOrWhiteSpace(formula)) {
                formula = "return 0.0";
            }
            calculate.Statements.Add(new CodeExpressionStatement(new CodeSnippetExpression(formula)));
            return calculate;
        }

        /// <summary>
        /// Compiles the c# into an assembly if there are no syntax errors
        /// </summary>
        /// <returns></returns>
        private CompilerResults CompileAssembly() {
            // create a provider
            CodeDomProvider provider = CreateCompiler();
            // get all the compiler parameters
            CompilerParameters parms = CreateCompilerParameters();
            // compile the code into an assembly
            CompilerResults results = CompileCode(provider, parms, _source.ToString());
            return results;
        }

        /// <summary>
        /// Runs the Calculate method in our on-the-fly assembly
        /// </summary>
        /// <param name="results"></param>
        private static void RunCode(CompilerResults results) {
            Assembly executingAssembly = results.CompiledAssembly;
            try {
                //cant call the entry method if the assembly is null
                if (executingAssembly != null) {
                    //object assemblyInstance = executingAssembly.CreateInstance("SolvisSC2Viewer.Calculator");
                    //Use reflection to call the static Main function

                    Module[] modules = executingAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types) {
                        Object handle = Activator.CreateInstance(type);
                        ICalculator iCalc = handle as ICalculator;
                        if (iCalc != null) {
                            CalculatorProxy.Calculator = iCalc;
                            return;
                        }
                    }
                }
            }
            catch (Exception) {
                CalculatorProxy.Calculator = null;
                //Console.WriteLine("Error:  An exception occurred while executing the script", ex);
            }
        }

        private static CodeDomProvider CreateCompiler() {
            //Create an instance of the C# provider   
            return new CSharpCodeProvider();
        }

        /// <summary>
        /// Create parameters for compiling
        /// </summary>
        /// <returns></returns>
        private static CompilerParameters CreateCompilerParameters() {
            //add compiler parameters and assembly references
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            compilerParams.ReferencedAssemblies.Add("SolvisSC2Viewer.exe");

            //add any aditional references needed

            return compilerParams;
        }

        /// <summary>
        /// Compiles the code from the code string
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="parms"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private CompilerResults CompileCode(CodeDomProvider provider, CompilerParameters parms, string source) {
            CompilerResults results = provider.CompileAssemblyFromSource(
                                        parms, source);

            if (results.Errors.Count > 0) {
                foreach (CompilerError error in results.Errors) {
                    WriteLine(Resources.CodeBuilderCompileError + error.ErrorText); //@Language Resource
                }
                MessageBox.Show(txtCompile, Resources.CodeBuilderFreeFormulas, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading); //@Language Resource
                return null;
            }
            return results;
        }

        /// <summary>
        /// Writes the output for a MessageBox
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="args"></param>
        private void WriteLine(string txt, params object[] args) {
            txtCompile += string.Format(CultureInfo.InvariantCulture, txt, args) + Environment.NewLine;
        }

        private void WriteLine(string txt) {
            txtCompile += txt + Environment.NewLine;
        }

        private static CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel) {
            CodeMemberField field = new CodeMemberField(type, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        private static CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel) {
            CodeMemberField field = new CodeMemberField(typeName, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        /// <summary>
        /// Very simplistic getter/setter properties
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="internalName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type) {
            CodeMemberProperty myProperty = new CodeMemberProperty();
            myProperty.Name = propertyName;
            //myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
            myProperty.Attributes = MemberAttributes.Public;
            myProperty.Type = new CodeTypeReference(type);
            myProperty.HasGet = true;
            myProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

            //myProperty.HasSet = true;
            //myProperty.SetStatements.Add(
            //    new CodeAssignStatement(
            //        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName),
            //        new CodePropertySetValueReferenceExpression()));

            return myProperty;
        }
    }
}
