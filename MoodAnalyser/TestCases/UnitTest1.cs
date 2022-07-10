using System;
using MoodAnalyser;

namespace MoodAnalyserTest
{

    public class AnalyseMoodTestCases
    {
        MoodAnalyserFactory factory = new MoodAnalyserFactory();
        [SetUp]
        public void Setup()
        {
            factory = new MoodAnalyserFactory();
        }

        //TC 4.1 - Proper class details are provided and expected to return the MoodAnalyser Object
        
        [TestCase("MoodAnalyser.MoodAnalysis", "MoodAnalysis")]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalysisObject(string className, string constructorName)
        {
            MoodAnalysis expected = new MoodAnalysis();
            object obj;

            factory = new MoodAnalyserFactory();
            obj = factory.CreatemoodAnalyse(className, constructorName);
            expected.Equals(obj);
        }
        //TC 4.2 - improper class details are provided and expected to throw exception Class not found
        
        [TestCase("Mood.MoodAnalysis", "MoodAnalysis", "class not found")]
        public void GivenImproperClassName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found

        [TestCase("MoodAnalyser.MoodAnalysis", "Mood", "constructor not found")]
        public void GivenImproperConstructorName_ShouldThrowCustomException(string className, string constructorName, string expected)
        {
            try
            {
                factory = new MoodAnalyserFactory();
                object actual = factory.CreatemoodAnalyse(className, constructorName);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        //TC 5.1 - Method to test moodanalyser class with parameter constructor to check if two objects are equal

        [TestCase("I am in sad mood")]
        [TestCase("I am in any mood")]
        public void GivenMoodAnalyserWhenProperShouldReturnMoodAnalyserObject(string message)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", "MoodAnalysis", message);
            }
            catch (CustomException actual)
            {
                Assert.That(actual.Message, Is.EqualTo(obj));
            }
            obj.Equals(expected);
        }
        //TC 5.2 - Method to test moodanalyser with diff class with parameter constructor to throw error

        [TestCase("Mood", "I am in Happy mood", "could not find class")]
        public void GIvenClassNmaeWhenImproperShouldThrowException(string className, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj = null;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject(className, "MoodAnalysis", message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }
        //TC 5.3 - Method to test moodanalyser with diff constructor with parameter constructor to throw error

        [TestCase("Mood", "I am in Happy mood", "could not find constructor")]
        public void GIvenConstructorNameWhenImproperShouldThrowException(string construtorName, string message, string expexted)
        {
            MoodAnalysis expected = new MoodAnalysis(message);
            object obj;
            try
            {
                factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyseParameterObject("MoodAnalysis", construtorName, message);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expexted, ex.Message);
            }
        }
        //UC 6.1,6.2 - Method to invoke analyse mood method to return happy or sad or invalid method

        [TestCase("HAPPY")]
        [TestCase("Method not found")]
        public void ReflectionReturnMethod(string expected)
        {
            try
            {
                string actual = factory.InvokeAnalyseMood("happy", "AnalyseMood");
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}



/// TC-6.1  Given Happy Message Using Reflection When Proper Should Return HAPPY Mood
/// To pass this TC use reflection to invoke analyseMood Method and show HAPPY mood
/// 
/// TC-6.2 Given Happy Message When Improper Method Should Throw MoodAnalysisException
/// To pass this Test Case pass wrong Method Name,
/// catch the Exception and throw indicating No Such Method Error

//TestCases
//  Tests in group: 9

//  Total Duration: 2.5 min

//Outcomes
//   9 Passed