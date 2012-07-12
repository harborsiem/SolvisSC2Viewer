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
using System.Windows.Forms;

namespace SolvisSC2Viewer {
    class CodeBuilder {
        private static object calculator;
        private static MethodInfo calculate1;
        private static MethodInfo calculate2;
        private static MethodInfo calculate3;

        string txtCompile;
        //string txtCalculate = "double i; i = 5.0 +7.0; double answer = i + rowValues.S10; return answer;";
        //string txtResult;

        StringBuilder _source = new StringBuilder();

        internal static double Calculate1(RowValues rowValues, SeriesState state) {
            if (calculator != null) {
                object result = calculate1.Invoke(calculator, new object[] { rowValues, state });
                return (double)result;
            }
            return 0.0;
        }

        internal static double Calculate2(RowValues rowValues, SeriesState state) {
            if (calculator != null) {
                object result = calculate2.Invoke(calculator, new object[] { rowValues, state });
                return (double)result;
            }
            return 0.0;
        }

        internal static double Calculate3(RowValues rowValues, SeriesState state) {
            if (calculator != null) {
                object result = calculate3.Invoke(calculator, new object[] { rowValues, state });
                return (double)result;
            }
            return 0.0;
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
            //            foreach (string refAssembly in code.References)
            //              compilerParams.ReferencedAssemblies.Add(refAssembly);

            return compilerParams;
        }

        /// <summary>
        /// Writes the output for a MessageBox
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="args"></param>
        private void WriteLine(string txt, params object[] args) {
            txtCompile += string.Format(txt, args) + Environment.NewLine;
        }

        /// <summary>
        /// Compiles the code from the code string
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="parms"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private CompilerResults CompileCode(CodeDomProvider provider, CompilerParameters parms, string source) {
            //actually compile the code
            CompilerResults results = provider.CompileAssemblyFromSource(
                                        parms, source);

            //Do we have any compiler errors?
            if (results.Errors.Count > 0) {
                foreach (CompilerError error in results.Errors) {
                    WriteLine("Compile Error: " + error.ErrorText);
                }
                MessageBox.Show(txtCompile, "Freie Formeln", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return null;
            }
            return results;
        }

        void InitializeFields() {
            //txtResult = "";
            txtCompile = "";
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

        public void Calculate(string formula1, string formula2, string formula3) {
            // Blank out result fields and compile result fields
            InitializeFields();

            //string formula1 = txtCalculate;

            // build the class using codedom
            BuildClass(formula1, formula2, formula3);

            //FileStream stream = File.Create(ConfigManager.ConfigDir + Path.DirectorySeparatorChar + "Calculator.cs");
            //StreamWriter writer = new StreamWriter(stream);
            //writer.Write(_source.ToString());
            //writer.Close();

            // compile the class into an in-memory assembly.
            // if it doesn't compile, show errors in the window
            CompilerResults results = CompileAssembly();

            //Console.WriteLine("...........................\r\n");
            //Console.WriteLine(_source.ToString());

            // if the code compiled okay,
            // run the code using the new assembly (which is inside the results)
            if (results != null && results.CompiledAssembly != null) {
                // run the evaluation function
                RunCode(results);
            } else {
                calculator = null;
            }
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
                    object assemblyInstance = executingAssembly.CreateInstance("SolvisSC2Viewer.Calculator");
                    calculator = assemblyInstance;
                    //Use reflection to call the static Main function

                    Module[] modules = executingAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types) {
                        MethodInfo[] mis = type.GetMethods();
                        foreach (MethodInfo mi in mis) {
                            if (mi.Name == "Calculate1") {
                                calculate1 = mi;
                                //object result = mi.Invoke(assemblyInstance, null);
                                //txtResult = result.ToString();
                            } else if (mi.Name == "Calculate2") {
                                calculate2 = mi;
                            } else if (mi.Name == "Calculate3") {
                                calculate3 = mi;
                            }
                        }
                    }

                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error:  An exception occurred while executing the script", ex);
            }
        }


        private static CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel) {
            CodeMemberField field = new CodeMemberField(typeName, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        private static CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel) {
            CodeMemberField field = new CodeMemberField(type, fieldName);
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
            myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
            myProperty.Attributes = MemberAttributes.Public;
            myProperty.Type = new CodeTypeReference(type);
            myProperty.HasGet = true;
            myProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

            myProperty.HasSet = true;
            myProperty.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName),
                    new CodePropertySetValueReferenceExpression()));

            return myProperty;
        }

        /// <summary>
        /// Main driving routine for building a class
        /// </summary>
        private void BuildClass(string formula1, string formula2, string formula3) {
            // need a string to put the code into
            _source = new StringBuilder();
            StringWriter sw = new StringWriter(_source);

            //Declare your provider and generator
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeGenerator generator = codeProvider.CreateGenerator(sw);
            CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

            CodeNamespace myNamespace = new CodeNamespace("SolvisSC2Viewer");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

            //Build the class declaration and member variables			
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
            classDeclaration.IsClass = true;
            classDeclaration.Name = "Calculator";
            classDeclaration.Attributes = MemberAttributes.Public;
            classDeclaration.Members.Add(FieldVariable("bVal1", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal2", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("bVal3", typeof(bool), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal1", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal2", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal3", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal4", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal5", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("dVal6", typeof(double), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal1", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal2", typeof(int), MemberAttributes.Private));
            classDeclaration.Members.Add(FieldVariable("iVal3", typeof(int), MemberAttributes.Private));
            
            //default constructor
            CodeConstructor defaultConstructor = new CodeConstructor();
            defaultConstructor.Attributes = MemberAttributes.Public;
            defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
            classDeclaration.Members.Add(defaultConstructor);

            //property
            //classDeclaration.Members.Add(this.MakeProperty("Answer", "answer", typeof(double)));

            //Our Calculate1 Method
            CodeMemberMethod myMethod1 = new CodeMemberMethod();
            myMethod1.Name = "Calculate1";
            myMethod1.ReturnType = new CodeTypeReference(typeof(double));
            myMethod1.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RowValues), "rowValues"));
            myMethod1.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SeriesState), "state"));
            myMethod1.Comments.Add(new CodeCommentStatement("Calculate an formula1", true));
            myMethod1.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (string.IsNullOrWhiteSpace(formula1)) {
                formula1 = "return 0.0";
            }
            myMethod1.Statements.Add(new CodeExpressionStatement(new CodeSnippetExpression(formula1)));
            //Our Calculate2 Method
            CodeMemberMethod myMethod2 = new CodeMemberMethod();
            myMethod2.Name = "Calculate2";
            myMethod2.ReturnType = new CodeTypeReference(typeof(double));
            myMethod2.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RowValues), "rowValues"));
            myMethod2.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SeriesState), "state"));
            myMethod2.Comments.Add(new CodeCommentStatement("Calculate an formula2", true));
            myMethod2.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (string.IsNullOrWhiteSpace(formula2)) {
                formula2 = "return 0.0";
            }
            myMethod2.Statements.Add(new CodeExpressionStatement(new CodeSnippetExpression(formula2)));
            //Our Calculate3 Method
            CodeMemberMethod myMethod3 = new CodeMemberMethod();
            myMethod3.Name = "Calculate3";
            myMethod3.ReturnType = new CodeTypeReference(typeof(double));
            myMethod3.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RowValues), "rowValues"));
            myMethod3.Parameters.Add(new CodeParameterDeclarationExpression(typeof(SeriesState), "state"));
            myMethod3.Comments.Add(new CodeCommentStatement("Calculate an formula3", true));
            myMethod3.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (string.IsNullOrWhiteSpace(formula3)) {
                formula3 = "return 0.0";
            }
            myMethod3.Statements.Add(new CodeExpressionStatement(new CodeSnippetExpression(formula3)));
            //myMethod1.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression(formula1)));
            //            myMethod1.Statements.Add(new CodeSnippetExpression("MessageBox.Show(String.Format(\"Answer = {0}\", Answer))"));
            //myMethod1.Statements.Add(
            //    new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
            classDeclaration.Members.Add(myMethod1);
            classDeclaration.Members.Add(myMethod2);
            classDeclaration.Members.Add(myMethod3);
            //write code
            myNamespace.Types.Add(classDeclaration);
            generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
            sw.Flush();
            sw.Close();
        }
    }
}
