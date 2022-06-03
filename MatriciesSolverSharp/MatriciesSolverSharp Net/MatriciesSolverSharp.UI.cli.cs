using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriciesSolverSharp_Net
{
    internal class MatriciesSolverSharpMenu
    {
        public void InitializeCLIMenu()
        {
            if(Program.debug_enable_global) Console.WriteLine("[Debug] Enter InitializeCLIMenu()");
        }

        public void RunCLIMenu()
        {
            if (Program.debug_enable_global) Console.WriteLine("[Debug] Enter RunCLIMenu()");
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Operations:");
                Console.WriteLine("" +
                    "Determinante of 2x2 Matrix: 1\r\n" +
                    "Determinante of 3x3 Matrix: 2\r\n" +
                    "\r\n" +
                    "Quit: q\r\n");

                char key;
                key = Console.ReadKey().KeyChar;

                switch(key)
                {
                    case '1':
                        {
                            if (Program.debug_enable_global) Console.WriteLine("[Debug] 2x2 Matrix Determinante");
                            detOf2x2Matrix();

                            Console.WriteLine("Execution finished, Press any key to return to the menu.");
                            break;
                        }
                    case '2':
                        {
                            if (Program.debug_enable_global) Console.WriteLine("[Debug] 3x3 Matrix Determinante");
                            detOf3x3Matrix();

                            Console.WriteLine("Execution finished, Press any key to return to the menu.");
                            break;
                        }
                    case 'q':
                        {
                            runMenu = false;
                            return;
                        }

                    default:
                        {
                            Console.WriteLine("INVALIDKEY, Press any key to refresh the menu.");
                            
                            break;
                        }
                }
                Console.ReadKey();

            }

        }

        public void FinalizeCLIMenu()
        {
            if (Program.debug_enable_global) Console.WriteLine("[Debug] Enter FinalizeCLIMenu()");
            Console.WriteLine("Quitting...");
        }

        public void detOf2x2Matrix()
        {
            float[,] inputMatrix = new float[2, 2];
            enterMatrix(ref inputMatrix);

            Console.WriteLine("Printing Input Matrix...");
            printMatrix(inputMatrix);

            Console.WriteLine("Calculating Determinante...");
            float det = MatriciesSolverSharpMathMatrix.MatrixDet(inputMatrix);
            Console.WriteLine("Determinante of Matrix: {0} or {1} AreaUnits", det.ToString(), Math.Abs(det).ToString());
        }

        public void detOf3x3Matrix()
        {
            //float[,] inputMatrix = new float[3, 3];
            //enterMatrix(ref inputMatrix, 3, 3);

            float[,] inputMatrix = new float[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Console.WriteLine("Printing Input Matrix...");
            printMatrix(inputMatrix, 3, 3);

            Console.WriteLine("Calculating Determinante...");
            float det = MatriciesSolverSharpMathMatrix.MatrixDet(inputMatrix, 3, 3);
            Console.WriteLine("Determinante of Matrix: {0} or {1} AreaUnits", det.ToString(), Math.Abs(det).ToString());
        }

        public void testMatrix()
        {
            float[,] testMatrix = new float[2, 2] { { 1, 2 }, { 2, 1 } };
        }

        //pls fix
        //make the thing take a reference
        public bool enterMatrix(ref float[,] matrix, int mRows = 2, int mLines = 2)
        {
            if (matrix.Length != (mRows*mLines)) { return false; }
            
            bool sucsess = true;
            Console.WriteLine("Enter a 2 by 2 matrix, return to finish a slot (I need a float)");
            for(int iLine = 0; iLine < mLines; iLine++)
            {
                for(int iRow = 0; iRow < mRows; iRow++)
                {
                    Console.Write("{0},{1}: ", iLine.ToString(), iRow.ToString());
                    string line = Console.ReadLine().Replace(",", ".");
                    float value;
                    sucsess = float.TryParse(line, out value);
                    if (sucsess == true) { matrix[iLine, iRow] = value;  }

                }
            }
            
            return sucsess;
        }

        public static bool printMatrix(float[,] matrix, int mRows = 2, int mLines = 2, int valSpace = 5)
        {
            bool sucsess = true;
            Console.WriteLine("Printing {0} by {1} Matrix...", mRows.ToString(), mLines.ToString());
            for(int iLines = 0; iLines < mLines; iLines++)

            {
                Console.Write("~|");

                for(int iRows = 0;iRows<mRows; iRows++)
                {
                    string builder = matrix[iLines, iRows].ToString();
                    if(builder.Length > valSpace) builder = builder.Substring(0, valSpace);
                    builder = builder.PadLeft(valSpace + 1);
                    Console.Write(builder);
                }

                Console.WriteLine("|~");
            }

            return sucsess;
        }
    }
}
