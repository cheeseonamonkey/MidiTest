using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MidiResults
{
    public byte[] HeaderBytes { get; set; }

    public byte[] TrackBytes { get; set; }
    public List<Track> Tracks { get; set; }

    public MidiResults()
    { }

    public string GetData()
    {
        string s = "";

        s += $"Header chunk (14 bytes):\n===================================\n";
        for(int i=0; i<4; i++)
            s += $"{HeaderBytes[i],-4}";
        s += "\n(\"MThd\" in ASCII, indicates file format)\n\n";

        for(int i=4; i<8; i++)
        {
            s += $"{HeaderBytes[i],-4}";
        }
        s += "\n(indicated size of header, usually 6)\n\n";

        for (int i = 8; i < 10; i++)
        {
            s += $"{HeaderBytes[i],-4}";
        }
        s += "\n(file format, 0 single track, 1 multiple tracks, 2 multiple async tracks)\n\n";

        for (int i = 10; i < 12; i++)
        {
            s += $"{HeaderBytes[i],-4}";
        }
        s += "\n(number of tracks)\n\n";

        for (int i = 12; i < 14; i++)
        {
            s += $"{HeaderBytes[i],-4}";
        }
        s += "\n(number of delta-time ticks per quarter note)\n\n";

        s += "Track chunks:\n===================================\n";

        



        return s;
    }

    public void ParseTracks()
    {

    }

    public class Track
    {
        public byte[] TrackHeader { get; set; }
        public byte[] TrackLength { get; set; }
        public byte[] TrackData { get; set; }

        public Track(byte[] bites)
        {
            List<byte> header = new List<byte>();
            List<byte> length = new List<byte>();
            List<byte> data = new List<byte>();

            for (int i = 0; i < 4; i++)
            {
                header.Add(bites[i]);
            }

            for (int i = 4; i < 6; i++)
            {
                length.Add(bites[i]);
            }








        }
    }
        
}
