using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr3
{
    class Infix
    {
        private StackX theStack;
        private StackY calcStack;
        private String input;
        private String output = "";
        //--------------------------------------------------------------
        public Infix(String input)   // constructor
        {
            this.input = input;
            theStack = new StackX(input.Length);
        }
        //--------------------------------------------------------------
        public double calculate()
        {
            calcStack = new StackY(input.Length);
            double sum = 0;
            for (int j = 0; j < output.Length; j++)
            {
                double first = 0, second = 0;
                char ch = output[j];
                if (!isOperator(ch))
                {
                    calcStack.push(double.Parse(ch.ToString()));
                    continue;
                }

                second = calcStack.pop();
                if (calcStack.size() != 0)
                {
                    first = calcStack.pop();
                }
                else
                {
                    sum = second;
                    break;
                }
                switch (ch)
                {
                    case '+':
                        //Console.Write(first + "+" + second);
                        sum = (first + second);
                        break;
                    case '-':
                        //Console.Write(first + "-" + second);
                        sum = (first - second);
                        break;
                    case '*':
                        //Console.Write(first + "*" + second);
                        sum = (first * second);
                        break;
                    case '/'://NOT USED
                        //Console.Write(first + "/" + second);
                        sum = (first / second);
                        break;
                }
                calcStack.push(sum);
                sum = 0;
                //Console.WriteLine(" [" + calcStack.size() + "]");// *diagnostic*
            } 
            sum = calcStack.pop();
            return Math.Round(sum, 2);//return awnser
        }
        private bool isOperator(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
            }
            return false;
        }
        //--------------------------------------------------------------
        public String toPostfix()      // do translation to postfix
        {
            for (int j = 0; j < input.Length; j++)
            {
                char ch = input[j];
                //theStack.displayStack("For " + ch + " "); // *diagnostic*
                switch (ch)
                {
                    case '+':       // it's + or -
                    case '-':
                        //output += " ";
                        gotOper(ch, 1); // go pop operators
                        break;          //   (precedence 1)
                    case '*':               // it's * or /
                    case '/':
                        //output += " ";
                        gotOper(ch, 2);      // go pop operators
                        break;               //   (precedence 2)
                    case '(':               // it's a left paren
                        theStack.push(ch);   // push it
                        break;
                    case ')':               // it's a right paren
                        gotParen(ch);        // go pop operators
                        break;
                    default:                // must be an operand
                        output += ch; // write it to output
                        break;
                }  // end switch
            }  // end for
            while (!theStack.isEmpty())     // pop remaining opers
            {
                //theStack.displayStack("While ");  // *diagnostic*
                output += theStack.pop(); // write to output
            }
            //theStack.displayStack("End   ");     // *diagnostic*
            return output;                   // return postfix
        }  // end doTrans()
        //--------------------------------------------------------------
        public void gotOper(char opThis, int prec1)
        {                                // got operator from input
            while (!theStack.isEmpty())
            {
                char opTop = theStack.pop();
                if (opTop == '(')            // if it's a '('
                {
                    theStack.push(opTop);      // restore '('
                    break;
                }
                else                          // it's an operator
                {
                    int prec2;                 // precedence of new op
                    if (opTop == '+' || opTop == '-') // find new op prec
                        prec2 = 1;
                    else
                        prec2 = 2;
                    if (prec2 < prec1)          // if prec of new op less
                    {                       //    than prec of old
                        theStack.push(opTop);   // save newly-popped op
                        break;
                    }
                    else                       // prec of new not less
                        output += opTop;  // than prec of old
                }  // end else (it's an operator)
            }  // end while
            theStack.push(opThis);        // push new operator
        }  // end gotOp()
        //--------------------------------------------------------------
        public void gotParen(char ch)
        {                             // got right paren from input
            while (!theStack.isEmpty())
            {
                char chx = theStack.pop();
                if (chx == '(')           // if popped '('
                    break;                  // we're done
                else                       // if popped operator
                    output += chx;  // output it
            }  // end while
        }  // end popOps()
        //--------------------------------------------------------------
    }
}
