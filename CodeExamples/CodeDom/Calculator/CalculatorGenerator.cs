using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeDom
{
    class CalculatorGenerator
    {
        public CalculatorGenerator()
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            CodeNamespace codeNameSpace = new CodeNamespace("Reflection");
            string[] nameSpaces = { "System", "System.Collections.Generic", "System.Linq", "System.Text", "System.Threading.Tasks" };
            
            importNameSpaces(codeNameSpace, nameSpaces);

            CodeTypeDeclaration targetClass = new CodeTypeDeclaration("Calculator");
            targetClass.IsClass = true;
            targetClass.TypeAttributes = TypeAttributes.Public;
            addMemberFields(targetClass);
            addMemberPropeties(targetClass);
            addMemberFunctions(targetClass);

            codeNameSpace.Types.Add(targetClass);
        }

        internal void addMemberFunctions(CodeTypeDeclaration targetClass)
        {
            
        }
        
        internal CodeMemberMethod createDivide(CodeMemberProperty x, CodeMemberProperty y)
        {
            CodeMemberMethod divideMethod = new CodeMemberMethod();
            divideMethod.Name = "Divide";
            divideMethod.ReturnType = createTypeReference<double>();
            divideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            CodeConditionStatement ifLogic = new CodeConditionStatement();
            CodeFieldReferenceExpression yReference = memberFieldReference(y.Name);
            ifLogic.Condition = new CodeBinaryOperatorExpression
                (   
                    yReference,
                    CodeBinaryOperatorType.ValueEquality,
                    new CodePrimitiveExpression(0)
                );

            CodeMethodReturnStatement trueStatement = new CodeMethodReturnStatement(new CodePrimitiveExpression(0));
            ifLogic.TrueStatements.Add(trueStatement);

            CodeBinaryOperatorExpression divisionLogic = new CodeBinaryOperatorExpression(memberFieldReference(x.Name),
                CodeBinaryOperatorType.Divide, memberFieldReference(y.Name));
            CodeMethodReturnStatement falseStatement = new CodeMethodReturnStatement(divisionLogic);
            ifLogic.FalseStatements.Add(falseStatement);
            divideMethod.Statements.Add(ifLogic);
            return divideMethod;
        }

        /// <summary>
        /// creates the member fields for the calculator class
        /// </summary>
        /// <param name="targetClass"></param>
        private void addMemberFields(CodeTypeDeclaration targetClass)
        {
            CodeMemberField xField = new CodeMemberField();
            xField.Name = "x";
            xField.Type = createTypeReference<double>();
            targetClass.Members.Add(xField);

            CodeMemberField yField = new CodeMemberField();
            yField.Name = "y";
            yField.Type = createTypeReference<double>();
            targetClass.Members.Add(yField);
            
        }

        /// <summary>
        /// creates the member properties for the calculator class
        /// </summary>
        /// <param name="targetClass"></param>
        private void addMemberPropeties(CodeTypeDeclaration targetClass)
        {
            CodeMemberProperty xProperty = new CodeMemberProperty();
            CodeMemberProperty yProperty = new CodeMemberProperty();
            xProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            xProperty.Name = "X";
            xProperty.HasGet = true;
            xProperty.HasSet = true;
            xProperty.Type = createTypeReference<System.Double>();
            addGeter(xProperty, "x");
            addSetter(xProperty, "x");
            targetClass.Members.Add(xProperty);

            yProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            yProperty.Name = "Y";
            yProperty.HasGet = true;
            yProperty.HasSet = true;
            yProperty.Type = createTypeReference<System.Double>();
            addGeter(yProperty, "y");
            addSetter(yProperty, "y");
            targetClass.Members.Add(yProperty);
        }

        /// <summary>
        /// will add a setter function to the passed property 
        /// pointed at the provided field name
        /// </summary>
        /// <param name="property"></param>
        /// <param name="fieldName"></param>
        private void addSetter(CodeMemberProperty property, string fieldName)
        {
            CodeFieldReferenceExpression fieldReference = memberFieldReference(fieldName);
            CodePropertySetValueReferenceExpression setExpresstion = new CodePropertySetValueReferenceExpression();
            CodeAssignStatement set = new CodeAssignStatement(fieldReference,setExpresstion);
            property.SetStatements.Add(set);
        }
        /// <summary>
        /// adds a getter for the provided property object
        /// pointed at the passed field name
        /// </summary>
        /// <param name="property"></param>
        /// <param name="fieldName"></param>
        private void addGeter(CodeMemberProperty property, string fieldName)
        {
            var fieldReferenceExpression = memberFieldReference(fieldName);
            var get = new CodeMethodReturnStatement(fieldReferenceExpression);
            property.GetStatements.Add(get);
           
        }

        private CodeFieldReferenceExpression memberFieldReference(string fieldName)
        {
            var thisReference = new CodeThisReferenceExpression();
            return new CodeFieldReferenceExpression(thisReference, fieldName);
        }
        /// <summary>
        /// Creates a type reference for the generic type
        /// </summary>
        /// <typeparam name="T">class type to create a type reference for</typeparam>
        /// <returns></returns>
        private static CodeTypeReference createTypeReference<T>()
        {
            return new CodeTypeReference(typeof(T));
        }

        /// <summary>
        /// imports the passed namespaces into the namespace
        /// </summary>
        /// <param name="codeNameSpace"></param>
        /// <param name="nameSpaces"></param>
        private void importNameSpaces(CodeNamespace codeNameSpace,string[] nameSpaces)
        {
            foreach(string nameSpace in nameSpaces)
            {
                codeNameSpace.Imports.Add(new CodeNamespaceImport(nameSpace));
            }
        }
        
        
    }
}
