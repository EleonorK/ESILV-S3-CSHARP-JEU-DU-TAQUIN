using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_3
{
    class Matrice
    {
        private string[,] mat;
        public Matrice(string[,] mat)
        {
            this.mat = mat;
        }
        public string[,] Mat
        {
            get { return this.mat; }
        }
        #region case vide
        /// <summary>
        /// permet de créer la case vide dans la matrice afin de la retrouver lors des déplacements ci dessous
        /// </summary>
        /// <returns></returns> la case vide sous forme de chaine de caractères
        public string CaseVide()
        {
            string[] b = null;
            int haut = 10;
            string c = null;
            if (this.mat != null)
            {
                for (int i = 0; i < this.mat.GetLength(1); i++)
                {
                    for (int k = 0; k < haut; k++)
                    {
                        for (int j = 0; j < this.mat.GetLength(0); j++)
                        {
                            b = this.mat[j, i].Split('\n');
                            if (i == 1 && j == 1)
                            {
                                b[k] = "                         ";
                                if (k < 10) { c += b[k] + '\n'; }
                            }
                        }
                    }
                }
            }
            return c;
        }
        #endregion
        #region Déplacements
        /// <summary>
        /// déplacement de la case vide vers la gauche
        /// </summary>
        public void Gauche()
        {
            string c = CaseVide();
            for (int i = 1; i < this.mat.GetLength(0); i++)
            {
                for (int j = 0; j < this.mat.GetLength(1); j++)
                {
                    if (this.mat[i, j] == c)
                    {
                        this.mat[i, j] = this.mat[(i - 1), j];
                        this.mat[(i - 1), j] = c;
                    }
                }
            }
        }
        /// <summary>
        /// déplacement de la case vide vers la droite
        /// </summary>
        public void Droite()
        {
            string c = CaseVide();
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 0; j < this.mat.GetLength(1); j++)
                {
                    if (this.mat[i, j] == c)
                    {
                        this.mat[i, j] = this.mat[(i + 1), j];
                        this.mat[(i + 1), j] = c;
                    }
                }
            }
        }
        /// <summary>
        /// déplacement de la case vide vers le haut
        /// </summary>
        public void Haut()
        {
            string c = CaseVide();
            for (int i = 0; i < this.mat.GetLength(0); i++)
            {
                for (int j = 1; j < this.mat.GetLength(1); j++)
                {
                    if (this.mat[i, j] == c)
                    {
                        this.mat[i, j] = this.mat[i, (j - 1)];
                        this.mat[i, (j - 1)] = c;
                    }
                }
            }
        }
        /// <summary>
        /// déplacement de la case vide vers le bas
        /// </summary>
        public void Bas()
        {
            string c = CaseVide();
            for (int i = 0; i < this.mat.GetLength(0); i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (this.mat[i, j] == c)
                    {
                        this.mat[i, j] = this.mat[i, (j + 1)];
                        this.mat[i, (j + 1)] = c;
                    }
                }
            }
        }
        #endregion
    }
}
