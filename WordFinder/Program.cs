using System;
using System.Collections.Generic;
using System.Linq;
using Application.MatrixProviders.Implementations;
using Application.WordFinders;
using Application.WordFinders.Implementations;
using Application.WordStreamProviders;
using Application.WordStreamProviders.Implementations;
using ConsoleApp.Helpers.Printers.ListPrinters;
using ConsoleApp.Helpers.Printers.ListPrinters.Implementations;
using ConsoleApp.Helpers.Requesters.Implementations;
using Domain.Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO-DO: Configure DI.  

            try
            {
                var matrixFilePath = new MatrixFilePathRequester().Request();
                var matrix = new FileHorizontalMatrixProvider(matrixFilePath).GetValidMatrix();

                var wordStreamFilePath = new WordStreamFilePathRequester().Request();
                var wordStream = new FileWordStreamProvider(wordStreamFilePath).GetValidWordStream();

                try
                {
                    var words = new WordFinder(matrix).FindWords(wordStream).ToList();

                    new RankedListPrinter().PrintList(words);
                }
                catch (NoMatchesException ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
                
            }
            catch (Exception ex)
            {
                var errorMessage = $"ERROR! \n \n {ex.Message}";

                Console.WriteLine(errorMessage);                
            }
        }
    }
}
