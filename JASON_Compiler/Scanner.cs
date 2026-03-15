using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//public enum Token_Class
//{
//    Begin, Call, Declare, End, Do, Else, EndIf, EndUntil, EndWhile, If, Integer,
 //   Parameters, Procedure, Program, Read, Real, Set, Then, Until, While, Write,
   // Dot, Semicolon, Comma, LParanthesis, RParanthesis, EqualOp, LessThanOp,
    //GreaterThanOp, NotEqualOp, PlusOp, MinusOp, MultiplyOp, DivideOp,
    //Idenifier, Constant
//}


public enum Token_Class
{
    // Reserved Keywords (من ملف الوصف)
    Int, Float, String, Read, Write, Repeat, Until, If, Elseif,
    Else, Then, Return, Endl, End, Main,

    // Operators & Symbols
    Semicolon, Comma, LParanthesis, RParanthesis, LCurlyBracket, RCurlyBracket,
    EqualOp, LessThanOp, GreaterThanOp, NotEqualOp,
    PlusOp, MinusOp, MultiplyOp, DivideOp,
    AssignmentOp, // ده عشان الـ :=

    // Logic Operators
    AndOp, OrOp, // عشان الـ && والـ ||

    // Dynamic Tokens
    Identifier, Constant, StringLiteral, Comment
}





namespace JASON_Compiler
{


    public class Token
    {
        public string lex;
        public Token_Class token_type;
    }

    public class Scanner
    {
        public List<Token> Tokens = new List<Token>();
        Dictionary<string, Token_Class> ReservedWords = new Dictionary<string, Token_Class>();
        Dictionary<string, Token_Class> Operators = new Dictionary<string, Token_Class>();

        public Scanner()
        {
            //ReservedWords.Add("IF", Token_Class.If);
            //ReservedWords.Add("BEGIN", Token_Class.Begin);
            //ReservedWords.Add("CALL", Token_Class.Call);
            //ReservedWords.Add("DECLARE", Token_Class.Declare);
            //ReservedWords.Add("END", Token_Class.End);
            //ReservedWords.Add("DO", Token_Class.Do);
            //ReservedWords.Add("ELSE", Token_Class.Else);
            //ReservedWords.Add("ENDIF", Token_Class.EndIf);
            //ReservedWords.Add("ENDUNTIL", Token_Class.EndUntil);
            //ReservedWords.Add("ENDWHILE", Token_Class.EndWhile);
            //ReservedWords.Add("INTEGER", Token_Class.Integer);
            //ReservedWords.Add("PARAMETERS", Token_Class.Parameters);
            //ReservedWords.Add("PROCEDURE", Token_Class.Procedure);
            //ReservedWords.Add("PROGRAM", Token_Class.Program);
            //ReservedWords.Add("READ", Token_Class.Read);
            //ReservedWords.Add("REAL", Token_Class.Real);
            //ReservedWords.Add("SET", Token_Class.Set);
            //ReservedWords.Add("THEN", Token_Class.Then);
            //ReservedWords.Add("UNTIL", Token_Class.Until);
            //ReservedWords.Add("WHILE", Token_Class.While);
            // ReservedWords.Add("WRITE", Token_Class.Write);


            ReservedWords.Add("int", Token_Class.Int);
            ReservedWords.Add("float", Token_Class.Float);
            ReservedWords.Add("string", Token_Class.String);
            ReservedWords.Add("read", Token_Class.Read);
            ReservedWords.Add("write", Token_Class.Write);
            ReservedWords.Add("repeat", Token_Class.Repeat);
            ReservedWords.Add("until", Token_Class.Until);
            ReservedWords.Add("if", Token_Class.If);
            ReservedWords.Add("elseif", Token_Class.Elseif);
            ReservedWords.Add("else", Token_Class.Else);
            ReservedWords.Add("then", Token_Class.Then);
            ReservedWords.Add("return", Token_Class.Return);
            ReservedWords.Add("endl", Token_Class.Endl);
            ReservedWords.Add("end", Token_Class.End);
            ReservedWords.Add("main", Token_Class.Main);

            /*Operators.Add(".", Token_Class.Dot);
            Operators.Add(";", Token_Class.Semicolon);
            Operators.Add(",", Token_Class.Comma);
            Operators.Add("(", Token_Class.LParanthesis);
            Operators.Add(")", Token_Class.RParanthesis);
            Operators.Add("=", Token_Class.EqualOp);
            Operators.Add("<", Token_Class.LessThanOp);
            Operators.Add(">", Token_Class.GreaterThanOp);
            Operators.Add("!", Token_Class.NotEqualOp);
            Operators.Add("+", Token_Class.PlusOp);
            Operators.Add("-", Token_Class.MinusOp);
            Operators.Add("*", Token_Class.MultiplyOp);
            Operators.Add("/", Token_Class.DivideOp);*/

            Operators.Add(";", Token_Class.Semicolon);
            Operators.Add(",", Token_Class.Comma);
            Operators.Add("(", Token_Class.LParanthesis);
            Operators.Add(")", Token_Class.RParanthesis);
            Operators.Add("{", Token_Class.LCurlyBracket);
            Operators.Add("}", Token_Class.RCurlyBracket);
            Operators.Add("+", Token_Class.PlusOp);
            Operators.Add("-", Token_Class.MinusOp);
            Operators.Add("*", Token_Class.MultiplyOp);
            Operators.Add("/", Token_Class.DivideOp);
            Operators.Add(":=", Token_Class.AssignmentOp); // imp fel  TINY 3shan el assignment operator hena mo5talf 
            Operators.Add("=", Token_Class.EqualOp);
            Operators.Add("<", Token_Class.LessThanOp);
            Operators.Add(">", Token_Class.GreaterThanOp);
            Operators.Add("<>", Token_Class.NotEqualOp);
            Operators.Add("&&", Token_Class.AndOp);
            Operators.Add("||", Token_Class.OrOp);



        }

        /*public void StartScanning(string SourceCode)
            {
                for(int i=0; i<SourceCode.Length;i++)
                {
                    int j = i;
                    char CurrentChar = SourceCode[i];
                    string CurrentLexeme = CurrentChar.ToString();

                    if (CurrentChar == ' ' || CurrentChar == '\r' || CurrentChar == '\n')
                        continue;

                    if (CurrentChar >= 'A' && CurrentChar <= 'z') //if you read a character
                    {

                    }

                    else if(CurrentChar >= '0' && CurrentChar <= '9')
                    {

                    }
                    else if(CurrentChar == '{')
                    {

                    }
                    else
                    {

                    }
                }

                JASON_Compiler.TokenStream = Tokens;
            }*/


        public void StartScanning(string SourceCode)
        {
            for (int i = 0; i < SourceCode.Length; i++)
            {
                char CurrentChar = SourceCode[i];
                string CurrentLexeme = "";

                // 1. تجاهل المسافات والسطور الجديدة
                if (char.IsWhiteSpace(CurrentChar))
                    continue;

                // 1.5 تجاهل الكومنتات بالكامل
                if (CurrentChar == '/' && i + 1 < SourceCode.Length && SourceCode[i + 1] == '*')
                {
                    i += 2;
                    while (i + 1 < SourceCode.Length && !(SourceCode[i] == '*' && SourceCode[i + 1] == '/'))
                    {
                        i++;
                    }
                    i++;

                    continue;
                }

                // 2. تجميع الـ Identifiers والـ Keywords
                if (char.IsLetter(CurrentChar))
                {
                    while (i < SourceCode.Length && (char.IsLetter(SourceCode[i]) || char.IsDigit(SourceCode[i])))
                    {
                        CurrentLexeme += SourceCode[i];
                        i++;
                    }
                    i--;
                    FindTokenClass(CurrentLexeme);
                }
                // 3. تجميع الـ Constants (الأرقام الصحيحة والعشرية)
                else if (char.IsDigit(CurrentChar))
                {
                    while (i < SourceCode.Length && (char.IsDigit(SourceCode[i]) || SourceCode[i] == '.'))
                    {
                        CurrentLexeme += SourceCode[i];
                        i++;
                    }
                    i--;
                    FindTokenClass(CurrentLexeme);
                }
                // 4. تجميع الـ String Literal (اللي بين "")
                else if (CurrentChar == '\"')
                {
                    CurrentLexeme += SourceCode[i];
                    i++;
                    while (i < SourceCode.Length && SourceCode[i] != '\"')
                    {
                        CurrentLexeme += SourceCode[i];
                        i++;
                    }
                    if (i < SourceCode.Length) CurrentLexeme += SourceCode[i];
                    FindTokenClass(CurrentLexeme);
                }
                // 5. تجميع الـ Operators والرموز المركبة
                else
                {
                    if (i + 1 < SourceCode.Length)
                    {
                        string nextTwo = SourceCode.Substring(i, 2);
                        // بنشيك على الرموز اللي من حرفين الأول
                        if (nextTwo == ":=" || nextTwo == "&&" || nextTwo == "||" || nextTwo == "<>")
                        {
                            CurrentLexeme = nextTwo;
                            i++;
                        }
                        else
                        {
                            CurrentLexeme = CurrentChar.ToString();
                        }
                    }
                    else
                    {
                        CurrentLexeme = CurrentChar.ToString();
                    }
                    FindTokenClass(CurrentLexeme);
                }
               
            }
            JASON_Compiler.TokenStream = Tokens;
        }


        /*void FindTokenClass(string Lex)
        {
            Token_Class TC;
            Token Tok = new Token();
            Tok.lex = Lex;
            //Is it a reserved word?
            

            //Is it an identifier?
            

            //Is it a Constant?

            //Is it an operator?

            //Is it an undefined?
        }*/

        void FindTokenClass(string Lex)
        {
            Token Tok = new Token();
            Tok.lex = Lex;

            // 1. هل هي كلمة محجوزة؟ (Keywords)
            if (ReservedWords.ContainsKey(Lex.ToLower()))
            {
                Tok.token_type = ReservedWords[Lex.ToLower()];
                Tokens.Add(Tok);
            }
            // 2. هل هي Identifier؟
            else if (isIdentifier(Lex))
            {
                Tok.token_type = Token_Class.Identifier;
                Tokens.Add(Tok);
            }
            // 3. هل هي رقم (Constant)؟
            else if (isConstant(Lex))
            {
                Tok.token_type = Token_Class.Constant;
                Tokens.Add(Tok);
            }
            // 4. هل هي Operator؟
            else if (Operators.ContainsKey(Lex))
            {
                Tok.token_type = Operators[Lex];
                Tokens.Add(Tok);
            }
            // is it a string
            else if (isString(Lex))
            {
                Tok.token_type = Token_Class.StringLiteral;
                Tokens.Add(Tok);
            }
            // 5. غير ذلك يعتبر Error
            else
            {
                Errors.Error_List.Add(Lex);
            }
        }



        /*bool isIdentifier(string lex)
        {
            bool isValid=true;
            // Check if the lex is an identifier or not.
            
            return isValid;
        }*/

        bool isIdentifier(string lex)
        {
            // Regular Expression: ^[a-zA-Z][a-zA-Z0-9]*$
            var re = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            return re.IsMatch(lex);
        }


        /*bool isConstant(string lex)
        {
            bool isValid = true;
            // Check if the lex is a constant (Number) or not.

            return isValid;
        }*/


        bool isConstant(string lex)
        {
            // Regular Expression: ^[0-9]+(\.[0-9]+)?$
            var re = new Regex(@"^[0-9]+(\.[0-9]+)?$");
            return re.IsMatch(lex);
        }

        bool isString(string lex)
        {
            var re = new Regex(@"^""[^""]*""$");
            return re.IsMatch(lex);

        }
    }
}




