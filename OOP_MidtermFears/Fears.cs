using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Midterm
{
    public class Fears
    {
        string path;
        List<string> distinctFears;

        public Fears(string path)
        {
            this.path = path;
        }
        
        public string[,] csvToArray()
        {    
            //csv dosyamızdan 2d array oluşturuyoruz.
            List<string> listA = new List<string>();
            var path = this.path;

            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] columns = line.Split(',');
                foreach (string column in columns)
                {
                    listA.Add(column); // oluşturduk fakat şu an 1 boyutlu.
                }
                
            }

            var height=lines.Length; //satır sayısı
            var width=lines[0].Split(',').Length; //sütun sayısı
            var index = 0;
            string[,] twoDimensionalArray = new string[height, width];
            
            for (var x = 0; x < height; x++)
            {
                for (var y = 0; y < width; y++)
                {
                    twoDimensionalArray[x, y] = listA[index]; // 2 boyutlu hale getirildi.
                    index++;
                }
            }

            
            return twoDimensionalArray;
        }

        public void showFearsAndNumbers(string[,] array2D)
        {
            Console.WriteLine("\nFears and their numbers.\n");
            List<string> fears = new List<string>(); // korku isimlerini tutmak için boş liste oluşturuldu.

            for (var i = 1; i < array2D.GetLength(0); i++)
            {
                fears.Add(array2D[i,0]); //verisetinin ilk sütununda bulunan korku isimleri listeye eklendi.
            }
            List<string> distinct = fears.Distinct().ToList(); // tekrar eden elemanlar listeden çıkarıldı.
            this.distinctFears = distinct;

            
            
            for (var i = 0; i < distinct.Count; i++)
            {
                var count = fears.FindAll(s => s == distinct[i]);
                Console.WriteLine($"{distinct[i]}: {count.Count}");  // her korku'nun ismi ve kaç tane bulunduğu yazdırıldı.
            }
        }

        public void Filter(string fear, string[,] array2D)
        {
            Console.WriteLine($"\nData for Filtered Fear ({fear})\n");
            List<int> index = new List<int>(); // istenen korkunun bulunduğu indexlerin tutlacağı boş liste oluşturuldu.
            var temp = 0;
            for (var i = 0; i < array2D.GetLength(0); i++)
            {
                
                if (array2D[i, 0] == fear)
                {
                    index.Add(i);  // indexler eklendi.
                }
                else
                {
                    temp++;  // 'korku' her satırda bulunmadıkça 'temp' 1 arttırılıyor.
                }
            }
            
            if (temp==array2D.GetLength(0)) // 'temp', verisetinin satır sayısına eşit ise korku bulunamamıştır.
            {
                Console.WriteLine($"{fear} is cannot found in dataset.");
            }
                
           
            index.Insert(0,0); // 0. index listenin başına eklenir.
            if (index.Count > 1) // liste eğer boşsa(yani korku bulunamamışsa) bu blok sayesinde yazdırılmıyor.
            {
                foreach (var i in index)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        Console.Write("{0,18}\t",array2D[i,j]);
                        // filtrelenen 'korku' nun bulunduğu indexler tablo şeklinde yazdırılıyor.
                    }
                    Console.WriteLine();
                }
            }
            
        }

        public void averageEncounter(string[,] array2D)
        {
            Console.WriteLine("\nAverage Encounter for Each Fear");
            foreach (var dist in this.distinctFears) // korkular listesindeki her korku döngüye giriyor.
            {
                List<int> indices = new List<int>();
                for (var i = 1; i < array2D.GetLength(0); i++)
                {
                
                    if (array2D[i, 0] == dist)
                    {
                        indices.Add(i); // bulunan indexler boş listeye ekleniyor.
                    }
                    
                }

                var totalEncounter = 0;
                foreach (var ind in indices)
                {
                    totalEncounter += Convert.ToInt32(array2D[ind, 4]);
                    // korkunun toplam tekrarlanma sıklığı hesaplanıyor.
                    
                }

                var averageEncounter = Convert.ToDouble(totalEncounter) / indices.Count;
                // korkunun ortalama tekrarlanma sıklığı hesaplanıyor.
                
                Console.WriteLine("{0,-25}: {1}",dist,averageEncounter);

            }
        }

        public void averageImpact(string[,] array2D)
        {
            Console.WriteLine("\nAverage Impact for Each Fear");
            foreach (var dist in this.distinctFears) // korkular listesindeki her korku döngüye giriyor.
            {
                List<int> indices = new List<int>();
                for (var i = 1; i < array2D.GetLength(0); i++)
                {

                    if (array2D[i, 0] == dist) 
                    {
                        indices.Add(i); // bulunan indexler boş listeye ekleniyor.
                    }

                }

                var totalImpact = 0;
                foreach (var ind in indices)
                {
                    totalImpact += Convert.ToInt32(array2D[ind, 2]);
                    // korkunun toplam etkisi hesaplanıyor.

                }

                var averageImpact = Convert.ToDouble(totalImpact) / indices.Count;
                // korkunun ortalama etkisi hesaplanıyor.

                Console.WriteLine("{0,-25}: {1}",dist,averageImpact);
            }

        }

        public void successOfOvercoming(string[,] array2D)
        {
            Console.WriteLine("\nSuccess of Overcoming for Each Fear");
            foreach (var dist in this.distinctFears) // korkular listesindeki her korku döngüye giriyor.
            {
                List<int> indices = new List<int>();
                for (var i = 1; i < array2D.GetLength(0); i++)
                {

                    if (array2D[i, 0] == dist)
                    {
                        indices.Add(i); // bulunan indexler boş listeye ekleniyor.
                    }

                }

                List<string> YesNoList = new List<string>();
                foreach (var ind in indices)
                {
                    YesNoList.Add(array2D[ind, 5]);
                    // overcoming sütunu boş listeye ekleniyor.
                }

                var countYes = YesNoList.FindAll(s => s == "Yes");
                var countNo = YesNoList.FindAll(s => s == "No");
                var success = Convert.ToDouble(countYes.Count) / Convert.ToDouble(YesNoList.Count) * 100;
                // yes, no sayıları bulunarak başarı yüzdesi hesaplanıyor.
                
                Console.WriteLine("{0,-20}:\tYes:{1}\tNo:{2}\tSuccess: %{3}",dist,countYes.Count,countNo.Count,success);
            }


        }
    }
}