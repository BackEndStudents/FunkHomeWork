using System.Reflection;
using FuncHW;
using FunkHomeWork.UnitTests.Enums;
using FunkHomeWork.UnitTests.Extensions;
using NUnit.Framework;

namespace FunkHomeWork.UnitTests;

public class FuncHomeWorkExtensionsTests
{
    Assembly _testAssembly = typeof(Program).Assembly;

    #region TestData

    private static Person _vasya = new()
        {Name = "Vasya", PhoneNumber = 12345, BirthDate = new DateTime(1999, 12, 12), IsActive = true};

    private static Person _petya = new()
        {Name = "Petya", PhoneNumber = 57348, BirthDate = new DateTime(2015, 11, 11), IsActive = true};

    private static Person _grisha = new()
        {Name = "Grisha", PhoneNumber = 78136, BirthDate = new DateTime(1964, 9, 9), IsActive = true};

    private static Person _gosha = new()
        {Name = "Gosha", PhoneNumber = 34825, BirthDate = new DateTime(1991, 10, 10), IsActive = false};

    private static Person _sveta = new()
        {Name = "Sveta", PhoneNumber = 75381, BirthDate = new DateTime(2010, 8, 8), IsActive = false};

    private static Person _nika = new()
        {Name = "Nika", PhoneNumber = 22387, BirthDate = new DateTime(2015, 7, 7), IsActive = true};

    private static Person _ira = new()
        {Name = "Ira", PhoneNumber = 96346, BirthDate = new DateTime(1988, 6, 6), IsActive = false};

    private static Cat _barsik = new() {Name = "Barsik", Color = "white", IsDomestic = false};
    private static Cat _pushok = new() {Name = "Pushok", Color = "white", IsDomestic = true};
    private static Cat _murzik = new() {Name = "Murzik", Color = "red", IsDomestic = false};
    private static Cat _dymok = new() {Name = "Dymok", Color = "black", IsDomestic = false};
    private static Cat _murka = new() {Name = "Murka", Color = "grey", IsDomestic = true};

    #endregion

    #region RightAnswers

    #region 1 variant

    private Cat _getLastCatIsDomesticAndWhite = _pushok;

    private Person _getLastPersonWhoHasShortName = _ira;

    #endregion


    #region 2 variant

    private Cat _getFirstCatNameWithU = _pushok;

    private Person _getFirstPersonIsActive = _vasya;

    #endregion


    #region 3 variant

    private int _countElementsPersonIsChild = 3;

    private int _countElementsCatsIsDomestic = 2;

    #endregion

    #region 4 variant

    private List<Cat> _selectWhereNotExtensionBlackCats = new()
    {
        _barsik, _pushok, _murzik
    };

    private List<Person> _selectWhereNotExtensionFirstNumber7Persons = new()
    {
        _vasya, _petya, _gosha, _nika, _ira
    };

    #endregion

    #endregion

    private List<Person> _persons;
    private List<Cat> _cats;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _persons = new() {_vasya, _petya, _gosha, _grisha, _sveta, _nika, _ira};
        _cats = new() {_barsik, _pushok, _murzik, _dymok, _murka};
    }

    [Test]
    public void ShouldReturnRightAnswerGetFirstExtension()
    {
        var getFirstExtension =
            _testAssembly.GetExtensionMethods(ExtensionsNamesEnum.GetFirst.ToString());

        var funcPersonIsActive = _testAssembly.GetFieldInfoByName(
            FunctionClassNames.PersonFunctions.ToString(),
            FunctionsNames.FuncPersonIsActive.ToString());

        var funcCatNameContainsU = _testAssembly.GetFieldInfoByName(
            FunctionClassNames.CatFunctions.ToString(),
            FunctionsNames.FuncCatNameContainsU.ToString());


        if (getFirstExtension != null && funcPersonIsActive != null && funcCatNameContainsU != null)
        {
            var personResult = getFirstExtension
                .MakeGenericMethod(typeof(Person))
                .Invoke(_persons, new[] {_persons, funcPersonIsActive.GetValue(funcPersonIsActive)});

            var catResult = getFirstExtension
                .MakeGenericMethod(typeof(Cat))
                .Invoke(_cats, new[] {_cats, funcCatNameContainsU.GetValue(funcCatNameContainsU)});

            Assert.That((Person) personResult!, Is.EqualTo(_getFirstPersonIsActive));
            Assert.That((Cat) catResult!, Is.EqualTo(_getFirstCatNameWithU));
        }
    }

    [Test]
    public void ShouldReturnRightAnswerGetLastExtension()
    {
        var getLastExtension =
            _testAssembly.GetExtensionMethods(ExtensionsNamesEnum.GetLast.ToString());

        var funcPersonHasShortName =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.PersonFunctions.ToString(),
                FunctionsNames.FuncPersonHasShortName.ToString());

        var funcCatIsDomesticAndWhite =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.CatFunctions.ToString(),
                FunctionsNames.FuncCatIsDomesticAndWhite.ToString());

        if (getLastExtension != null && funcPersonHasShortName != null && funcCatIsDomesticAndWhite != null)
        {
            var personResult = getLastExtension
                .MakeGenericMethod(typeof(Person))
                .Invoke(_persons, new[] {_persons, funcPersonHasShortName.GetValue(funcPersonHasShortName)});

            var catResult = getLastExtension
                .MakeGenericMethod(typeof(Cat))
                .Invoke(_cats, new[] {_cats, funcCatIsDomesticAndWhite.GetValue(funcCatIsDomesticAndWhite)});

            Assert.That((Person) personResult!, Is.EqualTo(_getLastPersonWhoHasShortName));
            Assert.That((Cat) catResult!, Is.EqualTo(_getLastCatIsDomesticAndWhite));
        }
    }

    [Test]
    public void ShouldReturnRightAnswerCountElementsExtension()
    {
        var countElementsExtension =
            _testAssembly.GetExtensionMethods(ExtensionsNamesEnum.CountElements.ToString());

        var funcPersonIsChild =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.PersonFunctions.ToString(),
                FunctionsNames.FuncPersonIsChild.ToString());

        var funcCatIsDomestic =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.CatFunctions.ToString(),
                FunctionsNames.FuncCatIsDomestic.ToString());

        if (countElementsExtension != null && funcPersonIsChild != null && funcCatIsDomestic != null)
        {
            var personResult = countElementsExtension
                .MakeGenericMethod(typeof(Person))
                .Invoke(_persons, new[] {_persons, funcPersonIsChild.GetValue(funcPersonIsChild)});

            var catResult = countElementsExtension
                .MakeGenericMethod(typeof(Cat))
                .Invoke(_cats, new object?[] {_cats, funcCatIsDomestic.GetValue(funcCatIsDomestic)});

            Assert.That((int) personResult!, Is.EqualTo(_countElementsPersonIsChild));
            Assert.That((int) catResult!, Is.EqualTo(_countElementsCatsIsDomestic));
        }
    }

    [Test]
    public void ShouldReturnRightAnswerSelectWhereNotExtension()
    {
        var selectWhereNotExtension =
            _testAssembly.GetExtensionMethods(ExtensionsNamesEnum.SelectWhereNot.ToString());

        var funcPersonPhoneWithFirst7 =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.PersonFunctions.ToString(),
                FunctionsNames.FuncPersonPhoneNumberStartsWith7.ToString());

        var funcCatColorIsDark =
            _testAssembly.GetFieldInfoByName(
                FunctionClassNames.CatFunctions.ToString(),
                FunctionsNames.FuncCatColorIsDark.ToString());

        if (selectWhereNotExtension != null && funcPersonPhoneWithFirst7 != null && funcCatColorIsDark != null)
        {
            var personResult = selectWhereNotExtension
                .MakeGenericMethod(typeof(Person))
                .Invoke(_persons, new[] {_persons, funcPersonPhoneWithFirst7.GetValue(funcPersonPhoneWithFirst7)});

            var catResult = selectWhereNotExtension
                .MakeGenericMethod(typeof(Cat))
                .Invoke(_cats, new[] {_cats, funcCatColorIsDark.GetValue(funcCatColorIsDark)});

            Assert.That((List<Person>) personResult!, Is.EqualTo(_selectWhereNotExtensionFirstNumber7Persons));
            Assert.That((List<Cat>) catResult!, Is.EqualTo(_selectWhereNotExtensionBlackCats));
        }
    }
}