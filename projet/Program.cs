using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Collections;

namespace projet_3
{
    class Program
    {
        #region utilitaire
        #region centrer le texte
        /// <summary>
        /// Pour centrer le texte écrit, code trouvé sur internet (c'est le seul programme pris sur internet)
        /// https://openclassrooms.com/fr/courses/1526901-apprenez-a-developper-en-c/2867826-une-console
        /// </summary>
        /// <param name="texte"></param> le texte affiché sur la console (à la ligne)
        static void CentrerLeTexte(string texte)
        {
            int nbEspaces = ((Console.WindowWidth - texte.Length) / 2);
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }
        /// <summary>
        /// Pour centrer le texte écrit, code trouvé sur internet (c'est le seul programme pris sur internet)
        /// https://openclassrooms.com/fr/courses/1526901-apprenez-a-developper-en-c/2867826-une-console
        /// </summary>
        /// <param name="texte"></param>le texte affiché sur la console (à la suite)
        static void CentrerLeTexteL(string texte)
        {
            int nbEspaces = ((Console.WindowWidth - texte.Length) / 2);
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.Write(texte);
        }
        #endregion
        #region securité centre
        /// <summary>
        /// c'est la sécurité pour la saisie d'un nombre ou un chiffre 
        /// </summary>
        /// <param name="min"></param> le minimum de la saisie
        /// <param name="max"></param> le maximum de la saisie
        /// <returns></returns> le chiffre ou nombre valide saisi par l'utilisateur
        static int SecuriteCentre(int min, int max)
        {
            int a = 0;
            bool test = true;
            string choix = null;
            do
            {
                choix = Console.ReadLine();
                try
                {
                    a = Int32.Parse(choix);
                    test = true;
                }
                catch
                {
                    test = false;
                }
                if (a < min || a > max || test == false)
                {
                    Console.WriteLine();
                    CentrerLeTexte("Cette option n'existe pas, veuillez saisir une option proposée ");
                    CentrerLeTexteL("Nouvelle saisie : ");
                }

            } while (a < min || a > max || test == false);
            return a;
        }
        #endregion
        #region erreur
        /// <summary>
        /// methode affichant la phrase de la Classe Erreurs et faisant retourner au Menu (si besoin)
        /// </summary>
        /// <param name="c"></param> la phrase d'erreur en fonction d'où elle est
        static void Erreur(string c)
        {
            Erreur phrase = new Erreur(c);
            CentrerLeTexteL(phrase.ErreurPG());
            int nb = SecuriteCentre(1, 2);
            switch (nb)
            {
                case 1:
                    Menu();
                    break;
                case 2:
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t Quitter . . .");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                   break;
            }
        }
        #endregion
        #region affichage matrice
        /// <summary>
        /// affichage de la matrice dans la console
        /// </summary>
        /// <param name="mat"></param> la matrice à afficher
        static void AffichageMatrice(string[,] mat)
        {
            string[] a = null;
            string c = CaseVide(mat);
            int haut = 10;
            if (mat != null)
            {
                for (int i = 0; i < mat.GetLength(1); i++)
                {
                    for (int k = 0; k < haut; k++)
                    {
                        for (int j = 0; j < mat.GetLength(0); j++)
                        {
                            a = mat[j, i].Split('\n');
                            if (mat[j, i] == c)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(a[k]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(a[k]);
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine("");
                    }
                }
            }
            else { Erreur("L'image n'existe pas (O_o)"); }
        }
        #endregion
        #region case vide
        /// <summary>
        /// création de la case vide 
        /// </summary>
        /// <param name="mat"></param>n'importe quelle matrice (mat ou matJeu), elle sert juste au dimension de la case vide
        /// <returns></returns> la case vide sous forme de chaine de caractères
        static string CaseVide(string[,] mat)
        {
            string[] b = null;
            int haut = 10;
            string c = null;
            if (mat != null)
            {
                for (int i = 0; i < mat.GetLength(1); i++)
                {
                    for (int k = 0; k < haut; k++)
                    {
                        for (int j = 0; j < mat.GetLength(0); j++)
                        {
                            b = mat[j, i].Split('\n');
                            if (i == 1 && j == 1)
                            {
                                b[k] = "                         ";
                                if (k < 10) { c += b[k] + '\n'; }
                            }
                        }
                    }
                }
            }
            else { Erreur("Impossible de créer la case vide (0.0)"); }
            return c;
        }
        #endregion
        #region retour au menu
        /// <summary>
        /// demande de menu ou quitter le jeu
        /// </summary>
        /// <param name="n"></param>pharse précédent le choix
        static void RetourMenu(string n)
        {
            CentrerLeTexte(n);
            CentrerLeTexte("1.Oui                    2.Non" + '\n');
            CentrerLeTexteL("Votre choix : ");
            int nb = SecuriteCentre(1, 2);
            switch (nb)
            {
                case 1:
                    Console.Clear();
                    Menu();
                    break;
                case 2:
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t Quitter . . .");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion
        #endregion
        #region menu
        /// <summary>
        /// Menu du jeu
        /// </summary>
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine();
            string image = null;
            CentrerLeTexte("****Menu****");
            Console.WriteLine();
            CentrerLeTexte("Bienvenue dans le jeu du Taquin");
            CentrerLeTexte("Quelle image voulez vous ?");
            CentrerLeTexte("1. Sapin                    2. Sims                    3. Visual                    4. Snap                    5. Quitter");
            Console.WriteLine();
            CentrerLeTexteL("Votre choix : ");
            int nb = SecuriteCentre(1, 6);
            switch (nb)
            {
                case 1:
                    Console.Clear();
                    CentrerLeTexte("**** SAPIN ****" + '\n');
                    image = File.ReadAllText("sapinAscii.txt");
                    MenuJeu(image);
                    break;
                case 2:
                    Console.Clear();
                    CentrerLeTexte("**** SIMS ****" + '\n');
                    image = File.ReadAllText("simsAscii.txt");
                    MenuJeu(image);
                    break;
                case 3:
                    Console.Clear();
                    CentrerLeTexte("**** VISUAL ****" + '\n');
                    image = File.ReadAllText("visualAscii.txt");
                    MenuJeu(image);
                    break;
                case 4:
                    Console.Clear();
                    CentrerLeTexte("**** SNAP ****" + '\n');
                    image = File.ReadAllText("snapAscii.txt");
                    MenuJeu(image);
                    break;
                case 5:
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t Quitter . . .");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion
        #region jeu
        #region regle du jeu
        /// <summary>
        /// règles du jeu
        /// </summary>
        /// <param name="image"></param> si le retour au choix de methodes de jeux est appelé (image = l'image choisi pour le jeu)
        static void RegleDuJeu(string image)
        {
            Console.WriteLine();
            CentrerLeTexte("Voulez vous les règles du jeu ?");
            CentrerLeTexte("1.Oui                    2.Non                    3.Retour" + '\n');
            CentrerLeTexteL("Votre choix : ");
            int nb = SecuriteCentre(1, 3);
            if (nb == 1)
            {
                Console.Clear();
                Console.WriteLine();
                CentrerLeTexte("**** Règle du Jeu ****");
                Console.WriteLine();
                Console.WriteLine("Le Taquin est un jeu solitaire en forme de damier. Le plateau de jeu présente une configuration originale");
                Console.WriteLine("(image, lettres, chiffres, etc.) gravée sur des panneaux carrés.");
                Console.WriteLine("Avant de commencer la partie, les panneaux sont dispatchés de manière aléatoire sur la grille de jeu.");
                Console.WriteLine("L’objectif pour le joueur est de remettre dans l’ordre ces panneaux afin de retrouver la configuration de départ.");
                Console.WriteLine("La partie est gagnée quand la disposition initiale est atteinte. Sur le plateau de jeu, il y a un emplacement vide.");
                Console.WriteLine("Cet emplacement vide permet de déplacer un panneau en le faisant glisser.");
                Console.WriteLine();
                CentrerLeTexte("Il suffit de déplacer la case vide, appuyez sur les chiffres ci-dessous :");
                Console.WriteLine();
                CentrerLeTexte("vers la doite : 6");
                CentrerLeTexte("vers la gauche : 4");
                CentrerLeTexte("vers le haut : 8");
                CentrerLeTexte("vers le bas : 2");
                CentrerLeTexte("si vous voulez abandonner : 0");
                Console.WriteLine();
                CentrerLeTexte("Appuyez sur '1' pour commencer");
                int a = SecuriteCentre(1, 1);
                Console.Clear();
            }
            if(nb == 3) { Console.Clear(); MenuJeu(image); }
        }
        #endregion
        #region conversion dans matrice
        /// <summary>
        /// conversion de l'image ("image.txt") en une matrice
        /// </summary>
        /// <param name="image"></param> l'image choisi pour le jeu
        /// <returns></returns> la matrice crée
        static string[,] ConversionImage(string image)
        {
            int longueur = 0;
            string[,] mat = null;
            if (image != null)
            {
                //verification de la taille de l'image
                string[] im1 = image.Split(new[] { "\n" }, StringSplitOptions.None);
                for (int i = 0; i < im1.Length; i++)
                {
                    if (i != im1.Length - 1)
                    {
                        if (im1[i].Length < im1[i + 1].Length)
                        {
                            longueur = im1[i + 1].Length;
                        }
                        if (im1[i].Length == im1[i + 1].Length)
                        {
                            longueur = im1[i].Length;
                        }
                    }
                }
                mat = new string[4, 4];
                int haut = im1.Length / 4, longu = longueur / 4;
                int numLi = 0, numCo = 0;
                //insertion de l'image dans la matrice
                for (int i = 0; i < im1.Length; i++)
                {
                    if (i == (haut * (numLi + 1)))
                    {
                        numLi++;
                    }
                    for (int j = 0; j < im1[i].Length; j++)
                    {
                        if (j == (longu * (numCo + 1)))
                        {
                            mat[numCo, numLi] += '\n';
                            numCo++;
                        }
                        mat[numCo, numLi] += im1[i][j];
                    }
                    mat[numCo, numLi] += '\n';
                    numCo = 0;
                }
            }
            else
            { Erreur("L'image n'existe pas ou est introuvable (x.o)"); }
            return mat;
        }
        #endregion
        #region creation vide
        /// <summary>
        /// transformation de la 16ème case (mat[3,3]) en la case vide
        /// </summary>
        /// <param name="image"></param> image choisie pour le jeu
        /// <returns></returns> la matrice avec la dernière case vide
        static string[,] VideCase(string image)
        {
            string[,] mat = ConversionImage(image);
            string c = CaseVide(mat);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (i == 3 && j == 3)
                    {
                        mat[i, j] = c;
                    }
                }
            }
            return mat;
        }
        #endregion
        #region menu jeu
        /// <summary>
        /// choix de la methode de jeu
        /// </summary>
        /// <param name="image"></param>image choisie pour le jeu
        static void MenuJeu(string image)
        {
            Console.WriteLine();
            CentrerLeTexte("**** Menu du jeu ****");
            Console.WriteLine();
            CentrerLeTexte("Voulez vous jouer au jeu avec un nombre de coups limité ou illimité ?");
            CentrerLeTexte("1.Limité                    2.Illimité                    3.IA (resolution par l'ordinateur)                    4.Retour" + '\n');
            CentrerLeTexteL("Votre choix : ");
            int nb = SecuriteCentre(1, 4);
            switch (nb)
            {
                case 1:
                    Console.WriteLine();
                    CentrerLeTexte("Combien de coups voulez vous disposer ?");
                    CentrerLeTexteL("Votre choix : ");
                    int coups = SecuriteCentre(1, 200);
                    JeuLimité(image, coups);
                    break;
                case 2:
                    Jeu(image);
                    break;
                case 3:
                    Ordi(image);
                    break;
                case 4:
                    Menu();
                    break;
            }
        }
        #endregion
        #region melange de la matrice
        /// <summary>
        /// mélange de la matrice
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        static string[,] Melange(string[,] mat)
        {
            //copie de la matrice ( avec la case vide )  dans la matrice jeu
            string[,] matJeu = new string[mat.GetLength(0), mat.GetLength(1)]; 
            Matrice matrice = new Matrice(null);
            if (mat != null)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        matJeu[i, j] = mat[i, j];
                    }
                }
                Random alea = new Random();
                int b = 0;
                //déplacements aléatoire de la case vide ( => empèche les resolutions impossible)
                if (matJeu != null)
                {
                    int a = 100;
                    while (b < a)
                    {
                        int c = alea.Next(1, 5);
                        Deplacements(matJeu, c, 0);
                        b++;
                    }
                }
                else { Erreur("Problème de copie de l'image (3o3)"); }
            }
            else { Erreur("Mélange impossible (XoX)"); }
            return matJeu;
        }
        #endregion
        #region verification matrices
        /// <summary>
        /// vérification que matJeu est egale ou pas à la matrice de départ (matrice sans mélange et ayant la dernière case vide)
        /// </summary>
        /// <param name="mat"></param> matrice de départ (matrice sans mélange et ayant la dernière case vide)
        /// <param name="matJeu"></param> matrice de jeu qui est modifiée par la fonction mélange et par les déplacement ( des utlisateurs ou de l'IA)
        /// <returns></returns> si elle est egale ou pas
        static bool Verif(string[,] mat, string[,] matJeu)
        {
            bool verif = false;
            int l = 0, m = 0, k = 16;
            if (mat != null && matJeu != null)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (mat[i, j] == matJeu[i, j]) { l++; }
                        if (mat[i, j] != matJeu[i, j]) { m++; }
                    }
                }
                if (l == k) { verif = true; }
            }
            else { Erreur("La verification de l'image est impossible (?_?)"); }
            return verif;
        }
        #endregion
        #region Deplacement case + saisie du mouvement
        #region Deplacement 
        /// <summary>
        /// déplacement des cases en fonction de la direction sélectionnée, à l'aide de la classe Matrice
        /// </summary>
        /// <param name="mat"></param> la matrice (jeu) qui est modifiée
        /// <param name="c"></param> la direction
        /// <param name="l"></param> déplacement normal ou à l'envers
        static void Deplacements(string [,] mat, int c, int l)
        {
            Matrice matrice = new Matrice(mat);
            // si l = 0, ça veut donc dire le déplacement se fait normalement
            if(l == 0)
            {
                if (c == 1) { matrice.Gauche(); }
                if (c == 2) { matrice.Droite(); }
                if (c == 3) { matrice.Haut(); }
                if (c == 4) { matrice.Bas(); }
                if (c == 0)
                {
                    Console.WriteLine();
                    CentrerLeTexte("Vous abandonnez ? ");
                    CentrerLeTexte("1.Oui (T_T)                    2.Non (^w^)" + '\n');
                    CentrerLeTexteL("Votre choix : ");
                    int nb = SecuriteCentre(1, 2);
                    switch (nb)
                    {
                        case 1:
                            Menu();
                            break;
                        case 2:
                            SaisieMouv(mat);
                            break;
                    }
                }
            }
            //si l = 1, c'est réservé SEULEMENT pour l'IA lors de la résolution
            if(l == 1)
            {
                if (c == 1) { matrice.Droite(); }
                if (c == 2) { matrice.Gauche(); }
                if (c == 3) { matrice.Bas(); }
                if (c == 4) { matrice.Haut(); }
            }
        }
        #endregion
        #region saisie mouv
        /// <summary>
        /// saisie du mouvement réservée exclusivement lors de la saisie utilisateurn (methode limité et methode illimité)
        /// conversion de la saisie pour correspondre a la methode Deplacement
        /// </summary>
        /// <param name="matJeu"></param> modification faite sur la matrice jouée
        static void SaisieMouv(string[,] matJeu)
        {
            int a = 10;
            do
            {
                Console.WriteLine();
                CentrerLeTexteL("Déplacez la case : ");
                a = SecuriteCentre(0, 8);
            } while (a != 4 && a != 6 && a != 8 && a != 2 && a != 0);
            
            if (a == 4) { a = 1; }
            if (a == 8) { a = 3; }
            if (a == 2) { a = 4; }
            if (a == 6) { a = 2; }
            Deplacements(matJeu, a, 0);
        }
        #endregion
        #endregion
        #region jeuuuu
        #region IA
        #region Random Coups
        /// <summary>
        /// pour les coups possibles en fonction de l'emplacement de la case pour le mélange de l'ordi (différent de la methode Mélange)
        /// </summary>
        /// <param name="a"></param> 1er valeur
        /// <param name="b"></param> 2 eme valeur
        /// <param name="c"></param> 3 eme valeur OU variable test
        /// <returns></returns> la valeurs valide 
        static int RandomCoups(int a, int b, int c)
        {
            Thread.Sleep(10);
            int resu = 0;
            Random alea = new Random();
            // si c = 0, le choix se fait qu'entre 2 valeurs (a et b)
            if (c == 0)
            {
                int d = alea.Next(1, 3);
                if (d == 1) { resu = a; }
                if (d == 2) { resu = b; }
            }
            // si c = 0, le choix se fait entre les 3 valeurs
            else
            {
                int d = alea.Next(1, 4);
                if (d == 1) { resu = a; }
                if (d == 2) { resu = b; }
                if (d == 3) { resu = c; }
            }
            return resu;
        }
        #endregion
        #region ordi
        /// <summary>
        /// methode qui execute l'ordinateur (mélanges, et résolution)
        /// </summary>
        /// <param name="image"></param> l'image choisi pour le jeu
        static void Ordi(string image)
        {
            Console.WriteLine();
            CentrerLeTexte("**** JEU ****");
            Console.WriteLine();
            CentrerLeTexte("C'est parti !");
            CentrerLeTexte("Voici la matrice mélangée");
            Console.WriteLine();
            string[,] mat = VideCase(image);
            //copie de la matrice dans la matrice jeu
            if (mat != null)
            {
                string[,] matJeu = new string[mat.GetLength(0), mat.GetLength(1)];
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        matJeu[i, j] = mat[i, j];
                    }
                }
                Random alea1 = new Random();
                int b = 0;
                if (matJeu != null)
                {
                    int a = 20;
                    Stack<int> pile = new Stack<int>();
                    int c = 0;
                    for (b = 0; b < a; b++)
                    {
                        c = alea1.Next(1, 5);
                        string caseV = CaseVide(mat);
                        //empecher les déplacement inutiles
                        for (int j = 0; j < matJeu.GetLength(0); j++)
                        {
                            for (int i = 0; i < matJeu.GetLength(1); i++)
                            {
                                if (matJeu[i, j] == caseV)
                                {
                                    if (j == 0)
                                    {
                                        if (i == 0) { c = RandomCoups(2, 4, 0); }
                                        if (i == 3) { c = RandomCoups(1, 4, 0); }
                                        if (i == 2 || i == 1) { c = RandomCoups(1, 4, 2); }
                                    }
                                    if (j == 1)
                                    {
                                        if (i == 0) { c = RandomCoups(3, 2, 4); }
                                        if (i == 3) { c = RandomCoups(3, 1, 4); }
                                    }
                                    if (j == 2)
                                    {
                                        if (i == 0) { c = RandomCoups(3, 2, 4); }
                                        if (i == 3) { c = RandomCoups(3, 1, 4); }
                                    }
                                    if (j == 3)
                                    {
                                        if (i == 0) { c = RandomCoups(3, 2, 0); }
                                        if (i == 3) { c = RandomCoups(3, 1, 0); }
                                        if (i == 2 || i == 1) { c = RandomCoups(1, 3, 2); }
                                    }
                                }
                            }
                        }
                        Deplacements(matJeu, c, 0);
                        pile.Push(c);
                    }
                    int g = 0;
                    AffichageMatrice(matJeu);
                    Console.WriteLine();
                    bool verif = false;
                    Matrice matrice1 = new Matrice(matJeu);
                    //résolution de l'IA
                    while (g < a && verif == false)
                    {
                        int k = pile.Pop();
                        Deplacements(matJeu, k, 1);
                        AffichageMatrice(matJeu);
                        Console.WriteLine();
                        verif = Verif(mat, matJeu);
                        Thread.Sleep(1000);
                        Console.Clear();
                        g++;
                    }
                    AffichageMatrice(matJeu);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    CentrerLeTexte("C'est finiiiiiii !! ");
                    Console.ResetColor();
                    Console.WriteLine();
                    RetourMenu("Voulez vous retourner au Menu ?");
                }
                else { Erreur("Problème de copie de l'image (3o3)"); }
            }
            else { Erreur("Impossble d'executer l'ordinateur (~.~)"); }
        }
        #endregion
        #endregion
        #region illimité
        /// <summary>
        /// methode résolution sans coups limite
        /// </summary>
        /// <param name="image"></param> l'image choisi pour le jeu
        static void Jeu(string image)
        {
            bool verif = false;
            int nb = 0;
            Console.Clear();
            Console.WriteLine();
            CentrerLeTexte("**** JEU ****");
            Console.WriteLine();
            string[,] mat = VideCase(image);
            string[,] matJeu = Melange(mat);
            RegleDuJeu(image);
            if (mat != null && matJeu != null)
            {
                CentrerLeTexte("C'est parti !");
                while (verif == false)
                {
                    AffichageMatrice(matJeu);
                    SaisieMouv(matJeu);
                    verif = Verif(mat, matJeu);
                    Console.Clear();
                    nb++;
                }
                AffichageMatrice(matJeu);
                Console.WriteLine();
                Console.WriteLine();
                CentrerLeTexte("Vous avez réussi en " + nb + " coups!!");
                Console.WriteLine();
                RetourMenu("Voulez-vous retourner au Menu ?");
            }
            else { Erreur("Impossible de lancer le jeu ('-')"); }
        }
        #endregion
        #region limité
        /// <summary>
        /// methode de résolution avec coups limités
        /// </summary>
        /// <param name="image"></param> l'image choisi pour le jeu
        /// <param name="coups"></param> le nombre de coups maximum
        static void JeuLimité(string image, int coups)
        {
            bool verif = false;
            int nb = 0;
            Console.Clear();
            Console.WriteLine();
            CentrerLeTexte("**** JEU ****");
            Console.WriteLine();
            string[,] mat = VideCase(image);
            string[,] matJeu = Melange(mat);
            RegleDuJeu(image);
            string phrase = null;
            int reste = coups;
            if (mat != null && matJeu != null)
            {
                CentrerLeTexte("C'est parti !");
                while (verif == false && nb < coups)
                {
                    AffichageMatrice(matJeu);
                    phrase = "Il vous reste " + reste + " coups.";
                    CentrerLeTexte(phrase);
                    SaisieMouv(matJeu);
                    verif = Verif(mat, matJeu);
                    Console.Clear();
                    reste--;
                    nb++;
                }
                AffichageMatrice(matJeu);
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                if (verif == false && nb >= coups) { CentrerLeTexte("Vous avez depassé le nombre de coups, PERDU (T_T)"); }
                if (verif == true && nb < coups) { CentrerLeTexte("Vous avez GAGNÉ en " + nb + " coups ! (^u^)"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                RetourMenu("Voulez-vous retourner au Menu ?");
            }
            else { Erreur("Impossible de lancer le jeu ('-')"); }
        }
        #endregion
        #endregion
        #endregion
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
    }
}
