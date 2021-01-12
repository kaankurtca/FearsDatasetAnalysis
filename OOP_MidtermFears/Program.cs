using System;
using System.IO;

namespace OOP_Midterm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = "FearStudyData.csv";
            Fears fr = new Fears(path); // class çağrıldı ve obje oluşturuldu.
            
            var array2D = fr.csvToArray(); // csv verisetimiz iki boyutlu diziye dönüştürüldü.
            
            fr.showFearsAndNumbers(array2D); 
            // Kullanıcı bu method ile hangi korkuların olduğunu ve kaçar tane olduğunu öğrenecek.
            
            fr.Filter("Being Alone",array2D);
            // Kulanıcı bu method ile sadece istediği korkuya ait verileri konsolda görebiliyor.
            
            fr.averageImpact(array2D);
            // Kullanıcı bu method ile her korkunun 'ortalama hayata etkisini' görebiliyor.
            
            fr.averageEncounter(array2D);
            // Kullanıcı bu method ile her korkunun 'ortalama tekrarlanma sıklığını' görebiliyor.
            
            fr.successOfOvercoming(array2D);
            // Kullanıcı bu method ile her korkunun 'üstesinden gelme başarısını' görebiliyor.
            
            
            // Not: csvToArray ve showFearsAndNumbers methodu öncelikle çağrılmalıdır ve 'korku'lar belirlenmelidir.
            // Daha sonra daha iyi gözlemlenmesi için diğer metotlar ayrı ayrı çağrılabilir.
            // Osman Kaan Kurtça - 040160090
            

        }
    }
}