////////////////////////////////////////////////////
//////// Calculator : giorgi kiparoidze ////////////
////////////////////////////////////////////////////

using System;

namespace Program{
    public class Calculator{

        //kalkulaciis funqcia
        public static string Calculation(string str){
            string? helpfulString = null;
            int?[] operantArray = new int?[100];
            char?[] operatorArray = new char?[99];
            for (int i = 0; i <str.Length; i++){
                if(str[i] != '-' || str[i] != '+' || str[i] != '*' || str[i] != '/' ){
                    helpfulString += str[i];
                }
                if(str[i] == '-' || str[i] == '+' || str[i] == '*' || str[i] == '/' ){
                    int helpfulInt = 0;
                    int finalNumber = int.Parse(helpfulString);
                    operantArray [helpfulInt] = finalNumber;

                    operatorArray [helpfulInt] = null;
                    char finalOperator = str[i];

                    ++helpfulInt;
                    operantArray [helpfulInt] = null;
                    operatorArray [helpfulInt] = finalOperator;

                }
            }
            for (int i = 0; i < operatorArray.Length; i++){
                if(operatorArray[i]== '*'){
                    operantArray[i-1] *= operantArray[i+1];
                    operantArray[i+1] =null;
                    operatorArray[i]=null;
                }
                if(operatorArray[i]== '/'){
                    operantArray[i-1] /= operantArray[i+1];
                    operantArray[i+1] =null;
                    operatorArray[i]=null;
                }
            }
            int? finalResult = operantArray[0];
            for (int i = 0; i<operatorArray.Length; i++){
                
                if (operatorArray[i] == null)continue;
                else if(operatorArray[i] == '+')finalResult += operantArray[i+1];
                else finalResult -= operantArray[i+1];
                
            }
            
            string Result = finalResult.ToString();
            return Result;

        }
        

        //gantolebashi frchxilebis sapovneli funqcia
        public static string CheckingForBrackets(string str){
            int firstBracketIndex = 0;
            int SecondBracketIndex = 0;
            
            for (int i = 0; i <str.Length; i++){
                if(str[i]== '(') firstBracketIndex = i;
                if(str[i] == ')') {SecondBracketIndex = i;break;}
                

            }
            if(firstBracketIndex == 0)
                goto lable_B;                    
            string bracketEquation = str;
            bracketEquation.Remove(0,firstBracketIndex);
            bracketEquation.Remove(SecondBracketIndex, bracketEquation.Length);

            string bracketEquationWithBrackets = str;
            bracketEquationWithBrackets.Remove(0,firstBracketIndex-1);
            bracketEquationWithBrackets.Remove(SecondBracketIndex+1, bracketEquationWithBrackets.Length);

            str = str.Replace(bracketEquationWithBrackets, Calculation(bracketEquation));
            CheckingForBrackets(str);
            lable_B:
            return Calculation(str);
            
        }


        public static void Main(string[] args){

            //matematikuri gantolebis shemotana kalkulatoristvis
            lable_A:
            System.Console.WriteLine("input the mathematical equation _ ");
            string? theEquation = Console.ReadLine();

            for(int i = 0; i < theEquation.Length; i++){
                if(theEquation[i] != '0' || theEquation[i] != '1' || theEquation[i] != '3' || theEquation[i] != '4' || 
                theEquation[i] != '8' || theEquation[i] != '7' || theEquation[i] != '6' || theEquation[i] != '5' || 
                theEquation[i] != '9' || theEquation[i] != '+' || theEquation[i] != '-' || theEquation[i] != '*' || 
                theEquation[i] != '(' || theEquation[i] != '/' || theEquation[i] != ')' ){
                    System.Console.WriteLine("equation does not have right simbols!!");
                    goto lable_A;
                }
                else continue;
            }

            System.Console.WriteLine($"{theEquation}={CheckingForBrackets(theEquation)}");

            lable_C:
            System.Console.WriteLine("gsurt sxva operaciis shesruleba? (daweret ki an ara)");
            string? userInput = Console.ReadLine();
            if(userInput == "ki"){
                goto lable_A;
            }
            else if(userInput == "ara"){
                return;
            }
            else goto lable_C;
        }
    }
}