using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsilvGui;

namespace JeuDeLaVie
{
    class Program
    {
       
        static int[,] Grille(int ligne, int colonne, double remplissage)
        {
            int[,] grille = new int[ligne, colonne];
            int totalRemplissage = Convert.ToInt16(remplissage * (colonne * ligne));
            Random rand = new Random();

            for(int h=0;h<totalRemplissage;h++)
            {
                int i = rand.Next(0, ligne);
                int j = rand.Next(0, colonne);
                if(grille[i, j] == 0)
                {
                    grille[i, j] = 1;
                }
                else
                {
                    h--;
                }
            }
            return grille;
        }
        
        static void AfficherGrille(int[,]grille)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {

                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i,j]==0)
                    {
                        
                        Console.Write(" . ");
                      

                    }
                    if (grille[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" # ");
                        Console.ResetColor();
                       

                    }
                    if (grille[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(" # ");
                        Console.ResetColor();


                    }
                    if (grille[i, j] == 2)
                    {
                        Console.ForegroundColor=ConsoleColor.Red;
                        Console.Write(" * ");
                        Console.ResetColor();


                    }
                    if (grille[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" - ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        static int[,] NewGrille(int[,] grille)
        {
            int[,] nouvelleGrille = new int[grille.GetLength(0), grille.GetLength(1)];
            for (int i = 0; i < nouvelleGrille.GetLength(0); i++)
            {
                for (int j = 0; j < nouvelleGrille.GetLength(1); j++) //Cette boucle for et celle du dessus permettent de faire passer le curseur sur chaque case de la matrice
                {
                    int compteur = 0;
                    int numLigne = i;
                    int numColonne = j;
                    for (numLigne = i - 1; numLigne <= i + 1; numLigne++)
                    {
                        for (numColonne = j - 1; numColonne <= j + 1; numColonne++) //Cette boucle for et celle du dessus permettent un scan des 8 cases autour du curseur
                        {
                            int numColonne2 = numColonne;
                            int numLigne2 = numLigne;
                            if (numLigne == grille.GetLength(0))//Si le curseur de scan est tout en bas de la matrice, la ligne du bas passe en haut de la matrice
                            {
                                numLigne = 0;
                            }
                            if (numLigne == -1)//Si le curseur de scan est tout en haut de la matrice, la ligne du haut passe en bas de la matrice
                            {
                                numLigne = grille.GetLength(0) - 1;
                            }
                            if (numColonne == -1)//Si le curseur de scan est tout à gauche de la matrice, la colonne de gauche passe à droite de la matrice 
                            {
                                numColonne = grille.GetLength(1) - 1;
                            }
                            if (numColonne == grille.GetLength(1))//Si le curseur de scan est tout à droite de la matrice, la colonne de droite passe à gauche de la matrice 
                            {
                                numColonne = 0;
                            }
                            if (grille[numLigne, numColonne] == 1)
                            {
                                compteur++;
                            }
                            numLigne = numLigne2;
                            numColonne = numColonne2;
                        }
                    }

                    if (grille[i, j] == 1)
                    {
                        compteur--;
                    }
                    
                    if (compteur < 2 || compteur > 3)
                    {
                        nouvelleGrille[i, j] = 0;
                    }
                    else
                    {
                        if (compteur == 3)
                        {
                            nouvelleGrille[i, j] = 1;
                        }
                    }
                }
            }
            return nouvelleGrille;
        }
            static int[,] GrilleEtatInter(int[,] grille, int ligne, int colonne)
        {
            int[,] grilleEtatInter = new int[ligne, colonne];

            for (int i = 0; i < grille.GetLength(0); i++)
            {

                for (int j = 0; j < grille.GetLength(1); j++)
                {

                    //Premiere ligne (ligne du haut)
                    int a = i;
                    int b = j;

                    int k = 0;


                    if (a == 0)
                        a = grille.GetLength(0);
                    if (b == 0)
                        b = grille.GetLength(0);

                    for (int ligne1 = 0; ligne1 < 3; ligne1++)
                    {
                        if (a == 0)
                            a = grille.GetLength(0);


                        if (grille[a - 1, b - 1] == 1)
                        {
                            k++;
                        }


                        if (b == grille.GetLength(1))
                        {
                            b = 1;
                        }
                        else
                        {
                            b++;
                        }

                    }

                    //2e ligne (ligne du bas)

                    a = i;
                    b = j;

                    if (a == grille.GetLength(0) - 1)
                        a = -1;
                    if (b == 0)
                        b = grille.GetLength(0);

                    for (int ligne2 = 0; ligne2 < 3; ligne2++)
                    {

                        if (grille[a + 1, b - 1] == 1)
                        {
                            k++;
                        }

                        if (b == grille.GetLength(1))
                        {
                            b = 1;
                        }
                        else
                        {
                            b++;
                        }




                    }


                    a = i;
                    b = j;

                    //case de gauche

                    if (j == 0)
                        b = grille.GetLength(1) - 1;
                    if (grille[a, b - 1] == 1)
                        k++;

                    //case de droite

                    b = j;
                    if (j == grille.GetLength(1) - 1)
                        b = 0;
                    if (grille[a, b + 1] == 1)
                        k++;

                    //On egalise la case

                    grilleEtatInter[i, j] = grille[i, j];

                    //On change les valeurs de la nouvelle matrice en fonction des regles du jeu

                    if ((grille[i, j] == 1) && (k < 2))
                        grilleEtatInter[i, j] = 2;

                    if ((grille[i, j] == 1) && (k > 3))
                        grilleEtatInter[i, j] = 2;
                    if ((grille[i, j] == 0) && (k == 3))
                        grilleEtatInter[i, j] = 3;



                }

            }
            return grilleEtatInter;

        }

        static int[,] Grille1v1(int ligne, int colonne, double remplissage)
        {
            int[,] grille = new int[ligne, colonne];
            int totalRemplissage = Convert.ToInt16(remplissage * (colonne * ligne)/2);
            Random rand = new Random();

            
                for(int k=0; k<totalRemplissage;k++)
                {
                    int i = rand.Next(0, ligne);
                    int j = rand.Next(0, colonne);
                    if (grille[i, j] == 0)
                    {
                        grille[i, j] = 1;
                    }
                    else
                    {
                        k--;
                    }
                }
                for (int k = 0; k < totalRemplissage; k++)
                {
                    int i = rand.Next(0, ligne);
                    int j = rand.Next(0, colonne);
                    if (grille[i, j] == 0)
                    {
                        grille[i, j] = 4;
                    }
                    else
                    {
                        k--;
                    }
                }


            

            return grille;

        }

        static int[,] GrilleNouvelleGen1v1(int[,] grille, int ligne, int colonne)
        {
            int[,] nouvelleGrille = new int[ligne, colonne];

            for (int i = 0; i < grille.GetLength(0); i++)
            {

                for (int j = 0; j < grille.GetLength(1); j++)
                {

                    //Premiere ligne (ligne du haut)
                    int a = i;
                    int b = j;

                    int pop1 = 0;
                    int pop2 = 0;


                    if (a == 0)
                        a = grille.GetLength(0);
                    if (b == 0)
                        b = grille.GetLength(0);

                    for (int ligne1 = 0; ligne1 < 3; ligne1++)
                    {
                        if (a == 0)
                            a = grille.GetLength(0);


                        if (grille[a - 1, b - 1] == 1)
                        {
                            pop1++;
                        }
                        if (grille[a - 1, b - 1] == 4)
                        {
                            pop2++;
                        }


                        if (b == grille.GetLength(1))
                        {
                            b = 1;
                        }
                        else
                        {
                            b++;
                        }

                    }

                    //2e ligne (ligne du bas)

                    a = i;
                    b = j;

                    if (a == grille.GetLength(0) - 1)
                        a = -1;
                    if (b == 0)
                        b = grille.GetLength(0);

                    for (int ligne2 = 0; ligne2 < 3; ligne2++)
                    {

                        if (grille[a + 1, b - 1] == 1)
                        {
                            pop1++;
                        }
                        if (grille[a + 1, b - 1] == 4)
                        {
                            pop2++;
                        }

                        if (b == grille.GetLength(1))
                        {
                            b = 1;
                        }
                        else
                        {
                            b++;
                        }




                    }


                    a = i;
                    b = j;

                    //case de gauche

                    if (j == 0)
                        b = grille.GetLength(1) - 1;
                    if (grille[a, b - 1] == 1)
                        pop1++;
                    if (grille[a, b - 1] == 4)
                        pop2++;

                    //case de droite

                    b = j;
                    if (j == grille.GetLength(1) - 1)
                        b = 0;
                    if (grille[a, b + 1] == 1)
                        pop1++;
                    if (grille[a, b + 1] == 4)
                        pop2++;

                    //On egalise la case

                    nouvelleGrille[i, j] = grille[i, j];

                    //On change les valeurs de la nouvelle matrice en fonction des regles du jeu

                    if ((grille[i, j] == 1) && (pop1 < 2))
                        nouvelleGrille[i, j] = 0;
                    if ((grille[i, j] == 4) && (pop2 < 2))
                        nouvelleGrille[i, j] = 0;

                    if ((grille[i, j] == 1) && (pop1 > 3))
                        nouvelleGrille[i, j] = 0;
                    if ((grille[i, j] == 4) && (pop2 > 3))
                        nouvelleGrille[i, j] = 0;

                    if ((grille[i, j] == 0) && (pop1 == 3))
                        nouvelleGrille[i, j] = 1;
                    if ((grille[i, j] == 0) && (pop2 == 3))
                        nouvelleGrille[i, j] = 4;




                }

            }
            return nouvelleGrille;

        }
        
        static int CompteurCellulesVivantes1v1(int[,] grille)
        {
            int compteur = 0;
            for (int i = 0; i < grille.GetLength(0); i++)
            {

                for (int j = 0; j < grille.GetLength(1); j++)
                {

                    if (grille[i, j] == 1)
                    {

                        compteur++;



                    }
                    if (grille[i, j] == 4)
                    {

                        compteur--;



                    }

                }
                
            }
            return compteur;
        }


        [System.STAThreadAttribute()]
        static void Main(string[] args)
        {
            int h = 1;


            do
            {
                Console.Clear();

                Console.WriteLine("Bienvenue au Jeu de la Vie !\n");

                Console.WriteLine("Saisir une valeur de remplissage : (entre 0,1 ou 1)");

                double remplissage = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Saisir un nombre de lignes : ");

                int ligne = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Saisir un nombre de colonnes : ");

                int colonne = Convert.ToInt16(Console.ReadLine());

                int[,] grille = Grille(ligne, colonne, remplissage);
                


                
                string g = "";
                int compteurGeneration = 1;
                string etatsInter = "";
                Console.Clear();

                Console.WriteLine("Voulez vous afficher les etats intermediaires ? (oui/non)");
                etatsInter = Convert.ToString(Console.ReadLine());

                do
                {
                    Console.Clear();
                    AfficherGrille(grille);         //Affiche la grille de la nouvelle generation dans la console.
                    Console.WriteLine("Generation n :" + compteurGeneration);       //Donne le numero de generation
                    Console.WriteLine("Il y a " + CompteurCellulesVivantes(grille) + " cellules vivantes");         // Affiche un compteur du nombre de cellules vivantes a la generation donnee.

                    

                    
                    if (etatsInter == "oui")
                    {
                        Console.WriteLine("Appuyer sur une touche pour continuer");
                        Console.ReadKey();
                        Console.Clear();
                        //Cree une grille intermediaire.
                        AfficherGrille(GrilleEtatInter(grille, ligne, colonne));
                        

                    }

                    Console.WriteLine("Appuyer sur Entree pour passer a la generation suivante, ou saisissez 'stop' pour arreter");
                    g = Convert.ToString(Console.ReadLine());
                    grille = GrilleNouvelleGen(grille, ligne, colonne);


                } while (g == "");

                Console.WriteLine("Voulez vous recommencer ou fermer le programme\n 1 : Recommencer\n 2: Fermer\n");
                h = Convert.ToInt16(Console.ReadLine());
                
            } while (h != 2);
            
            /*int h = 0;


            Console.Clear();

            Console.WriteLine("Bienvenue au Jeu de la Vie !\n");

            Console.WriteLine("Saisir une valeur de remplissage : (entre 0,1 ou 1)");

            double remplissage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Saisir un nombre de lignes : ");

            int ligne = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Saisir un nombre de colonnes : ");

            int colonne = Convert.ToInt16(Console.ReadLine());

            int[,] grille = Grille1v1(ligne, colonne, remplissage);

            do
            {
                AfficherGrille(grille);
                Console.ReadKey();
                Console.Clear();
                grille = GrilleNouvelleGen1v1(grille, ligne, colonne);
            } while (h != 1);
            
    */
        }
    }
}
