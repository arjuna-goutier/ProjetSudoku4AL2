using System;
using projetCS;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TestProjetCS1
{
    [TestFixture]
    public class SudReaderTest
    {

        public SudokuReader reader = new SudokuReader(new MockFileReader());

        [Test]
        public void should_success_when_valid() {
            var grilles = reader.readAll("valid.sud");
        }
        
        [Test]
        public void should_throw_FileNotFoundException_when_file_not_exists() {
            Assert.Throws<FileNotFoundException>(() =>
                reader.readAll("notExist.sud")
            );
        }
        
        [Test]
        public void should_throw_InvalidSudokuFileException_when_file_invalid() {
            Assert.Throws<InvalidSudokuFileException>(() =>
                reader.readAll("invalid.sud").ToArray()
            );
        }
    }


    public class MockFileReader : IFileReader
    {
        public bool Exists(string path) {
            switch (path) {
                case "invalid.sud":
                    return true;
                case "valid.sud":
                    return true;
                case "notExist.sud":
                    return false;
                default:
                    return false;
            }
        }
        public IEnumerable<string> ReadAllLines(string path) {
            switch (path) {
                case "invalid.sud":
                    return @"---------------------------------------
Test 1
10 avril 2006
123456789
623759184
457281369
819346257
246895731
395172648
781463592
134528976
568917423
972634815
---------------------------------------
Test 2
10 avril 2006
123456789
3152948a7
864571392
729386154
943812576
576439281
182657439
631928745
457163928
298745613
---------------------------------------
Test 3
18 avril 2006
123456789
142675389
675893241
389412765
961527834
258349617
437168592
726984153
893251476
514736928
---------------------------------------
Test 4
18 avril 2006
123456789
192348576
786125493
453976218
238561947
975234681
641789352
317492865
824657139
569813724
".Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                case "valid.sud":
                    return @"---------------------------------------
Test 1
10 avril 2006
123456789
623759184
457281369
819346257
246895731
395172648
781463592
134528976
568917423
972634815
---------------------------------------
Test 2
10 avril 2006
123456789
315294867
864571392
729386154
943812576
576439281
182657439
631928745
457163928
298745613
---------------------------------------
Test 3
18 avril 2006
123456789
142675389
675893241
389412765
961527834
258349617
437168592
726984153
893251476
514736928
---------------------------------------
Test 4
18 avril 2006
123456789
192348576
786125493
453976218
238561947
975234681
641789352
317492865
824657139
569813724
".Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                case "notExist.sud":
                    throw new DirectoryNotFoundException();
                default :
                    throw new DirectoryNotFoundException();
            }
        }
    }
}
