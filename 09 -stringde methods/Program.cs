using static System.Net.Mime.MediaTypeNames;

namespace stringde_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cumle = "I am Backend DEVELOPER I LEARN C#";


            Console.WriteLine(SaitleriTap(cumle));


            Console.WriteLine(SozlerinSayi(cumle));


            Console.WriteLine(EnUzunSoz(cumle));


            BoyukHerfler(cumle);


            IkiBOyukHErif(cumle);
        }
        #region 1.Verilmis string-de sait herflewrin tapilmasi
        public static string SaitleriTap(string cumle)
        {

            string saitler = "aəeıioöuü";

            var tapilan = cumle.ToLower().Where(c => saitler.Contains(c));

            int a = tapilan.Count();

            string b = string.Join(", ", tapilan);

            //Console.WriteLine("Saitler: " + string.Join(", ", tapilan));
            return $"verilmis cumledeki saitler {b} sayi ise {a}-dir";
        }
        #endregion
        #region 2.Verilmish string-de sozlerin bosluga gore sayi.
        public static int SozlerinSayi(string cumle)
        {
            int sozlerinSayi = cumle.Split(" ").Length;
            return sozlerinSayi;


        }
        #endregion
        #region 3.Verilmiş stringin-in ən uzun sözünü ekrana çıxaran proqram yazın
        public static string EnUzunSoz(string cumle)
        {
            string[] soz = cumle.Split(" ");
            int k = 0;
            int max = soz[0].Length;
            for (int i = 1; i < soz.Length; i++)
            {
                if (soz[i].Length > max)
                {
                    max = soz[i].Length;
                    k = i;
                }

            }
            return $"en uzun soz {soz[k]}-dir";

        }
        #endregion
        #region 4.Verilmiş string-in bütün hərfləri böyük olan sözün özünü və indeksini çapa çıxaran proqram yazın
        public static void BoyukHerfler(string cumle)
        {

            string[] sozler = cumle.Split(' ');
            int index = 0;
            for (int i = 0; i < sozler.Length; i++)
            {
                if (sozler[i] == sozler[i].ToUpper())
                {
                    index = cumle.IndexOf(sozler[i], index);
                    Console.WriteLine($"boyuk herf olan sozder {sozler[i]} ve indexi {index}");
                }
                if (sozler[i] == sozler[i + 1])
                {
                    index = index + 1;
                }

            }




        } 
        #endregion
        #region 5. Verilmiş string-in 2-dən artıq böyük hərfi olan elementlərini çapa çıxaran proqram yazın
        public static void IkiBOyukHErif(string cumle)
        {
            string[] words = cumle.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                int upperCount = 0;

                for (int j = 0; j < words[i].Length; j++)
                {
                    if (char.IsUpper(words[i][j]))
                        upperCount++;
                }

                if (upperCount > 2)
                {
                    Console.WriteLine(words[i]);
                }
            }
        } 
        #endregion





    }
}
