using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ByteReader
{
    public ByteReader()
    {
    }

    //write method for debugging sanity
    public void WriteToBin()
    {
        FileStream fileStream = File.Open("stuff.bin", FileMode.Create);

        //Something is fucky in this method
        //I think it is failing to write


        byte bite = (byte) Convert.ToSByte(8);
        Console.WriteLine($"{bite}");

        BinaryWriter binWriter = new BinaryWriter(fileStream);

        binWriter.Flush();
        binWriter.Close();
    }

    

    public MidiResults ReadMidiFile(string file)
    {
        FileStream fileStream = File.Open(file, FileMode.Open);

        BinaryReader binReader = new BinaryReader(fileStream);

        MidiResults results = new MidiResults();

        //read 8 byte header
        ReadHeader();

        //close resources
        binReader.Close();
        return results;

        //local methods
        void ReadHeader()
        {
            byte[] headerBites = binReader.ReadBytes(14);

            results.HeaderBytes = headerBites;
        }

        void ReadTracks()
        {
            List<byte> trackBytes = new List<byte>();

            while (binReader.PeekChar() > 0)
            {
                trackBytes.Add(binReader.ReadByte());
            }

            results.TrackBytes = trackBytes.ToArray();
        }


        //===============

    }
}

