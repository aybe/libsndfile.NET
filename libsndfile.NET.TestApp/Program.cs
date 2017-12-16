using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using libsndfile.NET.Helpers;

namespace libsndfile.NET.TestApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("No path argument specified.");
                return;
            }

            var source = args[0];

            using (var sf = SndFile.OpenRead(source))
            {
                if (sf == null)
                    throw new ArgumentNullException(nameof(sf));

                var calcSignalMax = sf.CalcSignalMax();
                var calcNormSignalMax = sf.CalcNormSignalMax();
                var calcMaxAllChannels = sf.CalcMaxAllChannels();
                var calcNormMaxAllChannels = sf.CalcNormMaxAllChannels();
                var signalMax = sf.GetSignalMax();
                var maxAllChannels = sf.GetMaxAllChannels();
                var normFloat = sf.SetNormFloat(!sf.GetNormFloat());
                var normDouble = sf.SetNormDouble(!sf.GetNormDouble());
                var scaleFloatIntRead = sf.SetScaleFloatIntRead(true);
                var scaleIntFloatWrite = sf.SetScaleIntFloatWrite(true);
            }

            PrintFormats();
        }

        private static void PrintFormats()
        {
            Console.WriteLine("\r\nGetSimpleFormat");
            for (var i = 0; i < SfCommands.GetSimpleFormatCount(); i++)
            {
                var info = SfCommands.GetSimpleFormat(i);
                if (info == null) throw new ArgumentNullException(nameof(info));
                Console.WriteLine(info);
            }

            Console.WriteLine("\r\nGetFormatInfo major");
            var majors = Enum.GetValues(typeof(SfFormatMajor)).Cast<SfFormatMajor>();
            foreach (var major in majors)
            {
                var info = SfCommands.GetFormatInfo(major);
                if (info == null) throw new ArgumentNullException(nameof(info));
                Console.WriteLine(info);
            }

            Console.WriteLine("\r\nGetFormatInfo subtype");
            foreach (var subtype in Enum.GetValues(typeof(SfFormatSubtype)).Cast<SfFormatSubtype>())
            {
                var info = SfCommands.GetFormatInfo(subtype);
                if (info == null) throw new ArgumentNullException(nameof(info));
                Console.WriteLine(info);
            }

            Console.WriteLine("\r\nGetFormatMajor");
            for (var i = 0; i < SfCommands.GetFormatMajorCount(); i++)
            {
                var info = SfCommands.GetFormatMajor(i);
                if (info == null) throw new ArgumentNullException(nameof(info));
                Console.WriteLine(info);
            }

            Console.WriteLine("\r\nGetFormatSubtype");
            for (var i = 0; i < SfCommands.GetFormatSubtypeCount(); i++)
            {
                var info = SfCommands.GetFormatSubtype(i);
                if (info == null) throw new ArgumentNullException(nameof(info));
                Console.WriteLine(info);
            }
        }

        private static void Transcode(string source)
        {
            {
                Console.WriteLine("Transcoding using a file");
                var destination = Path.GetTempFileName();
                TranscodeFile(source, destination);
                File.Delete(destination);
            }

            {
                Console.WriteLine("Transcoding using a virtual file system");
                var destination = Path.GetTempFileName();
                TranscodeVirtual(source, destination);
                File.Delete(destination);
            }
        }

        private static void TranscodeFile([NotNull] string source, [NotNull] string destination)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            using (var input = SndFile.OpenRead(source))
            using (var output = SndFile.OpenWrite(destination, SfFormat.DefaultFlac))
            {
                if (input == null)
                    throw new InvalidOperationException(SndFile.GetErrorMessage());

                if (output == null)
                    throw new InvalidOperationException(SndFile.GetErrorMessage());

                TranscodeInternal(input, output);
            }
        }

        private static void TranscodeVirtual([NotNull] string source, [NotNull] string destination)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            using (var helper1 = new SfVirtualStreamHelper(File.OpenRead(source)))
            using (var helper2 = new SfVirtualStreamHelper(File.Create(destination)))
            using (var input = SndFile.OpenRead(helper1.Virtual))
            using (var output = SndFile.OpenWrite(helper2.Virtual, SfFormat.DefaultFlac))
            {
                if (input == null)
                    throw new InvalidOperationException(SndFile.GetErrorMessage());

                if (output == null)
                    throw new InvalidOperationException(SndFile.GetErrorMessage());

                TranscodeInternal(input, output);
            }
        }

        private static void TranscodeInternal([NotNull] SndFile input, [NotNull] SndFile output)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            const int frames = 1024;
            var buffer = new short[frames * input.Format.Channels];
            long read;
            long done = 0;
            Console.CursorVisible = false;
            do
            {
                read = input.ReadFrames(buffer, frames);

                var write = output.WriteFrames(buffer, read);
                if (write != read)
                    throw new InvalidOperationException();

                done += write;
                Console.WriteLine($"{(float) done / input.Frames:P}");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            } while (read == frames);
            Console.WriteLine();
        }
    }
}