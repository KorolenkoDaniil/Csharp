using System;
using System.Collections;

namespace Lab19_1_4
{
    public class Disk
    {
        public string _name { get; set; }

        Hashtable hashtable = new Hashtable();


        public Disk (string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return $"{_name}";
        }


        public void PrtntSongsWithSinger(string SingerName)
        {
            if (hashtable.Count == 0)
            {
                Console.WriteLine("на диске нету музыки ");
            }
            else
            {
                foreach (var value in hashtable.Keys)
                {
                    if (hashtable[value].ToString() == SingerName)
                    {
                        Console.WriteLine($"песня: {value}  Исполнитель: {hashtable[value]}");
                    }
                }
            }
        }


        public void PrtntSongs()
        {
            if (hashtable.Count == 0)
            {
                Console.WriteLine("на диске нету музыки ");
            }
            else
            {
                foreach (var value in hashtable.Keys)
                {
                    Console.WriteLine($"песня: {value}  Исполнитель: {hashtable.Values}");
                }
            }
        }


        public void AddSong(string song, object singer)
        {
            if (!hashtable.ContainsKey(song))
            {
                hashtable.Add(song, singer);
                Console.WriteLine("Элемент успешно добавлен.");
            }
            else
            {
                Console.WriteLine("Элемент с таким ключом уже существует.");
            }
        }

        public void DeleteSong(string song)
        {
            if (hashtable.ContainsKey(song))
            {
                hashtable.Remove(song);
                Console.WriteLine("Элемент успешно удален.");
            }
            else
            {
                Console.WriteLine("Такой песни нету на данном диске");
            }
        }

    }
}
