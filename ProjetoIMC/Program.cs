using System;
using System.IO;

namespace ProjetoIMC
{
    public struct Cadastro
    {
        public string s_Nm { get; set; }
        public int i_Id { get; set; }
        public double d_Pe { get; set; }
        public string s_Ge { get; set; }
        public double d_IMC { get; set; }
        public double d_Alt { get; set; }
        public string s_Cla { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string s_Path = @"..\Agenda.txt";

            string s_Resp = "";
            bool b_Continua = false;
            Cadastro st_Cadastro = new Cadastro();

            do
            {
                Console.Clear();
                s_Resp = "";

                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("▒ C - CALCULAR IMC  ▒");
                Console.WriteLine("▒ L - VER IMC       ▒");
                Console.WriteLine("▒ S - SAIR          ▒");
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n");
                Console.Write("Sua opção: ");
                s_Resp = Console.ReadLine().ToUpper();

                switch (s_Resp)
                {
                    case "C":
                        {
                            st_Cadastro = pegaCadastro(st_Cadastro);
                            StreamWriter sw = new StreamWriter(s_Path, true);
                            PopulaAgenda(st_Cadastro, sw);
                            break;
                        }

                    case "L":
                        {
                            StreamReader sr = new StreamReader(s_Path);

                            while (!(sr.EndOfStream))
                            {
                                Console.WriteLine(sr.ReadLine());
                            }
                            sr.Close();
                            break;
                        }

                    case "S":
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opção invalida...\n\n");
                            break;
                        }
                }

                Console.WriteLine("Deseja Continuar para o menu? (S/N)");
                b_Continua = Console.ReadLine().ToUpper() == "S" ? true : false;

            } while (b_Continua);
        }
        public static void PopulaAgenda(Cadastro pst_Cadastro, StreamWriter psw)
        {
            psw.WriteLine("-------------------------------------------");
            psw.WriteLine("    Nome:             " + pst_Cadastro.s_Nm);
            psw.WriteLine("    Idade:            " + pst_Cadastro.i_Id);
            psw.WriteLine("    Gênero:           " + pst_Cadastro.s_Ge);
            psw.WriteLine("    Peso:             " + pst_Cadastro.d_Pe);
            psw.WriteLine("    Altura:           " + pst_Cadastro.d_Alt);
            psw.WriteLine("    IMC:              " + pst_Cadastro.d_IMC);
            psw.WriteLine("    Classificação:    " + pst_Cadastro.s_Cla);
            psw.WriteLine("-------------------------------------------");
            string[] s_classrate = { pst_Cadastro.i_Id.ToString(), pst_Cadastro.d_IMC.ToString(), pst_Cadastro.s_Cla };
            foreach (string i in s_classrate)
            {
                psw.WriteLine(i);
            }
            psw.WriteLine("-------------------------------------------");
            psw.Close();
        }

        public static Cadastro pegaCadastro(Cadastro pst_Cadastro)
        {
            Console.Write("Digite seu nome: ");
            pst_Cadastro.s_Nm = Console.ReadLine();
            Console.Write("Digite sua idade: ");
            pst_Cadastro.i_Id = Convert.ToInt16(Console.ReadLine());
            Console.Write("Digite seu gênero M/F: ");
            pst_Cadastro.s_Ge = Console.ReadLine();
            Console.Write("Digite seu peso (kg): ");
            pst_Cadastro.d_Pe = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite sua altura (metros): ");
            pst_Cadastro.d_Alt = Convert.ToDouble(Console.ReadLine());

            switch (pst_Cadastro.s_Ge.ToUpper())
            {
                case "M":

                    pst_Cadastro.d_IMC = (double)(pst_Cadastro.d_Pe / Math.Pow(pst_Cadastro.d_Alt, 2));

                    if (pst_Cadastro.d_IMC < 20)
                    {
                        pst_Cadastro.s_Cla = "Abaixo do normal";
                    }
                    else
                    {
                        if (pst_Cadastro.d_IMC < 25)
                        {
                            pst_Cadastro.s_Cla = "Normal";
                        }
                        else
                        {
                            if (pst_Cadastro.d_IMC < 30)
                            {
                                pst_Cadastro.s_Cla = "Obesidade Leve";
                            }
                            else
                            {
                                if (pst_Cadastro.d_IMC > 30 && pst_Cadastro.d_IMC < 40)
                                {
                                    pst_Cadastro.s_Cla = "Obesidade Moderada";
                                }
                                else
                                {
                                    pst_Cadastro.s_Cla = "Obesidade Mórbida";
                                }
                            }
                        }
                    }
                    Console.WriteLine("Você está classificado como: " + pst_Cadastro.s_Cla + "\nSeu IMC é: " + pst_Cadastro.d_IMC);
                    break;

                case "F":

                    pst_Cadastro.d_IMC = (double)(pst_Cadastro.d_Pe / Math.Pow(pst_Cadastro.d_Alt, 2));

                    if (pst_Cadastro.d_IMC < 19)
                    {
                        pst_Cadastro.s_Cla = "Abaixo do normal";
                    }
                    else
                    {
                        if (pst_Cadastro.d_IMC < 24)
                        {
                            pst_Cadastro.s_Cla = "Normal";
                        }
                        else
                        {
                            if (pst_Cadastro.d_IMC < 29)
                            {
                                pst_Cadastro.s_Cla = "Obesidade Leve";
                            }
                            else
                            {
                                if (pst_Cadastro.d_IMC < 29 && pst_Cadastro.d_IMC < 39)
                                {
                                    pst_Cadastro.s_Cla = "Obesidade Moderada";
                                }
                                else
                                {
                                    pst_Cadastro.s_Cla = "Obesidade Mórbida";
                                }
                            }
                        }
                    }
                    Console.WriteLine("Você está classificado como: " + pst_Cadastro.s_Cla + "\nSeu IMC é: " + pst_Cadastro.d_IMC);
                    break;

                default:

                    Console.WriteLine("Erro!\n\n");
                    break;
            }

            return pst_Cadastro;
        }
    }
}
