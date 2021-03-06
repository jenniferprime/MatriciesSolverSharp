using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriciesSolverSharp_Net
{
    internal class MatriciesSolverSharpMathMatrix
    {
        //public static MatriciesSolverSharp Instance { get; set; } #
        enum determinantAlgo { Laplace, Gausian };
        public enum operation { Add, Subtract, Divide, Multiply };
        
        //gets a 2 by 2 matrix and returns, if sucsessful it's determinante. if it's not successful it will return 1337.
        public static float MatrixDet(float[,] matrix, int mRows = 2, int mLines = 2)
        {
            
            if ((mRows == mLines) && matrix.Length == mLines*mRows)
            {
                if (mRows == 2)
                {
                    float m_Diagonal = matrix[0, 0] * matrix[1, 1];
                    float n_Diagonal = matrix[0, 1] * matrix[1, 0];

                    float value = m_Diagonal - n_Diagonal;
                    return value;
                }
                else if(mRows == 3)
                {
                    //Diagonal Rule, Surres

                    float[,] projectionMatrix = new float[3, 5];

                    createProjectionMatrix(ref matrix, ref projectionMatrix);

                    if (Program.debug_enable_global) { Console.WriteLine("[Debug] Printing Projection Matrix for debugging"); MatriciesSolverSharpMenu.printMatrix(projectionMatrix, 5, 3); }

                    float[] m_Diagonal = new float[3];
                    float m_DiagonalMultiply = 0.0f;
                    for (int i = 0; i<3;i++)
                    {
                        m_Diagonal[i] = MainDiagonal(ref projectionMatrix, 5, 3, i);
                    }
                    m_DiagonalMultiply = m_Diagonal[0] + m_Diagonal[1] + m_Diagonal[2];


                    float[] a_Diagonal = new float[3];
                    float a_DiagonalMultiply = 0.0f;
                    for (int i = 0; i<3; i++)
                    {
                        a_Diagonal[i] = AltDiagonal(ref projectionMatrix, 5, 3, i);
                    }

                    a_DiagonalMultiply = a_Diagonal[0] + a_Diagonal[1] + a_Diagonal[2];
                    //pls fix deleting the arrays to save all the space, although this might only be a C++ thing.
                    return m_DiagonalMultiply - a_DiagonalMultiply;
                }
                else
                {
                    throw new NotImplementedException();
                    /*if(determinantAlgo == determinantAlgo.Laplace)
                    {
                        
                    }*/
                    return 1337;
                }
                    
            }    
            //pls fix
            else { return 1337;  }
        }

        public static float MainDiagonal(ref float[,] matrix, int mRows = 2, int mLines = 2, int mOffset = 0)
        {
            float work = 1.0f;
            if(mRows == mLines)
            {
                //Used for normal calculation of the determinant.
                for(int i = 0; i<mRows;i++)
                {
                    work = work * matrix[i, i];
                }
            }
            else if(mLines == 3 && mRows == 5)
            {
                //Used for Diagonal Rule
                for (int i = 0; i<mLines; i++)
                {
                    work = work * matrix[i, i+mOffset];
                }
            }
            else
            {
                //pls fix 1337
                return 1337;
            }
            return work;
        }

        public static float AltDiagonal(ref float[,] matrix, int mRows = 2, int mLines = 2, int mOffset = 0)
        {
            float work = 1.0f;
            if (mRows == mLines)
            {
                for (int i = mRows; i>0; i--)
                {
                    work = work * matrix[i, i];
                }
            }
            else if (mLines == 3 && mRows == 5)
            {
                //Used for Diagonal Rule
                //for (int i = 0; i<3; i++)
                //{
                //    work = work * matrix[i, i+mOffset];
                //}
                //I think this sometimes works

                //I want    0,2->1,1->2,0
                //          0,3->1,2->2,1
                //          0,4->1,3->2,2

                for (int i = 0; i<mLines; i++)
                {
                    work = work * matrix[i, 2-i+mOffset];
                }
            }
            else
            {
                //pls fix 1337
                return 1337;
            }
            return work;
        }

        public static bool createProjectionMatrix(ref float[,] sourceMatrix, ref float[,] projectionMatrix)
        {
            //pls fix: implement checks for size
            for (int iRow = 0; iRow < 3; iRow++)
            {
                projectionMatrix[0, iRow] = sourceMatrix[0, iRow];
                projectionMatrix[1, iRow] = sourceMatrix[1, iRow];
                projectionMatrix[2, iRow] = sourceMatrix[2, iRow];
                if (iRow == 0 || iRow == 1)
                {
                    projectionMatrix[0, iRow+3] = sourceMatrix[0, iRow];
                    projectionMatrix[1, iRow+3] = sourceMatrix[1, iRow];
                    projectionMatrix[2, iRow+3] = sourceMatrix[2, iRow];
                }
            }
            return true;
        }

        public static bool MatrixOperation(ref Matrix outMatrix, ref Matrix matrixA, ref Matrix matrixB, operation operation = operation.Add)
        {
            //make sure the matrices have the same row and collumn count
            //pls fix check that outMatrix is also the same size as A and B
            if (matrixA.mRowCount == matrixB.mRowCount && matrixA.mColumnCount == matrixB.mColumnCount)
            {
                //pls fix, missing try catch block

                switch (operation)
                {
                    case operation.Add:
                    {
                            for (int iRow = 0; iRow<matrixA.mRowCount;iRow++)
                            {
                                for (int iCol = 0; iCol<matrixA.mColumnCount; iCol++)
                                {
                                    outMatrix.mValues[iRow, iCol] = matrixA.mValues[iRow, iCol] + matrixB.mValues[iRow, iCol];
                                }
                            }
                            return true;
                            //pls fix break redundant?
                            break;
                    }
                    case operation.Subtract:
                        {
                            for (int iRow = 0; iRow<matrixA.mRowCount; iRow++)
                            {
                                for (int iCol = 0; iCol<matrixA.mColumnCount; iCol++)
                                {
                                    outMatrix.mValues[iRow, iCol] = matrixA.mValues[iRow, iCol] - matrixB.mValues[iRow, iCol];
                                }
                            }
                            return true;
                            //pls fix break redundant?
                            break;
                        }
                    default:
                        {
                            return false;
                            //pls fix break redundant?
                            break;
                        }
                }
            }
            else { return false; }
            //pls fix, reduntant return?
            return true;
        }

        private bool helpMultiplyMatrix(ref Matrix outMatrix, ref Matrix matrixA, ref Matrix matrixB)
        {
            //not adding size checks, as this function should only be called by "MatrixOperation()"
            

            //this is the one where we use the falkthing

            /*
             *      Nomatrix|Bmatrix
             *      Amatrix |Outmatrix
             *      
             *      -   -   -   |   a   b   c  
             *      -   -   -   |   d   e   f
             *      -   -   -   |   g   h   i
             *      __________________________
             *      a   b   c   |   A   B   C
             *      d   e   f   |   D   E   F
             *      g   h   i   |   G   H   I
             */

            //first attempt at making a thing where i'm going through the out matrix and trying to figure out what values I have to add/multiply
            for(int iRow = 0; iRow < outMatrix.mRowCount; iRow++)
            {
                for(int iCol = 0; iCol < outMatrix.mColumnCount; iCol++)
                {
                    
                    //the col needs to got the Bmatrix and Row needs to go to the Amatrix

                    //this is the loop that does the thing with the indicies of the new matrix
                    //pls fix, check if this works
                    //pls fix, make this into a loop so the things make sense
                    float value = (matrixA.mValues[iRow, 0] * matrixB.mValues[0, iCol]) + (matrixA.mValues[iRow, 1] * matrixB.mValues[1, iCol]) + (matrixA.mValues[iRow, 2] * matrixB.mValues[2, iCol]);

                    outMatrix.mValues[iRow, iCol] = value;
                }
            }

            return true;
        }
    }
    
    internal class Matrix
    {
        public  float[,]    mValues;
        public  int         mIndex;
        public  int         mRowCount;  
        public  int         mColumnCount;
    }
}
