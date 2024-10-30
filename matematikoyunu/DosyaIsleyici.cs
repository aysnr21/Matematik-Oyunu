using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace matematikoyunu
{
    class DosyaIsleyici
    {
        public string dosyayolu;
        public FileStream filestream;
        public StreamWriter streamwriter;
        public StreamReader streamreader;
        public List<int> skorlar = new List<int>();

        public DosyaIsleyici(string dosyayolu)
        {
            this.dosyayolu = dosyayolu;
            if (!Directory.Exists(Path.GetDirectoryName(dosyayolu)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dosyayolu));
            }
            filestream = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            streamwriter = new StreamWriter(filestream);
        }

        public void BaglantiKapat()
        {
            streamwriter.Close();
            filestream.Close();
        }

        public void SkorYaz(string veri)
        {
            streamreader = new StreamReader(filestream);
            while(true)
            {
                string skor = streamreader.ReadLine();

                if (skor == "" || skor == null)
                    break;

                skorlar.Add(Convert.ToInt32(skor));
            }

            BaglantiKapat();

            File.Delete(dosyayolu);
            FileStream fs = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            skorlar.Add(Convert.ToInt32(veri));

            for (int i = 0; i < skorlar.Count; i++)
            {
                sw.WriteLine(skorlar[i].ToString());
            }

            sw.Close();
            fs.Close();
        }

        public void KalanSeviyeYaz(string veri)
        {
            File.Delete(dosyayolu);
            FileStream fs = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(veri);

            sw.Close();
            fs.Close();
        }

        public int KalanSeviyeAl()
        {
            streamreader = new StreamReader(filestream);
            string level = streamreader.ReadLine();

            switch (Convert.ToInt32(level))
            {
                case 1:
                    return 1;
                    

                case 2:
                    return 2;
                    

                case 3:
                    return 3;
                    

                case 4:
                    return 4;
                   

                case 5:
                    return 5;
                 
            }

            return 0;
        }
    }
}
