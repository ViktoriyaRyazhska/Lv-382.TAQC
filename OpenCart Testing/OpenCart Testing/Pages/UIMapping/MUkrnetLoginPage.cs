using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MUkrnetLoginPage
    {
        public static By locatorUkrnetUsername => By.XPath("//input[@id = 'id-l']");
        public static By locatorUkrnetPassword => By.XPath("//input[@id = 'id-p']");
        public static By locatorLoginButton => By.XPath("//button[@class = 'button button_style-main button_size-regular form__submit']");
    }
}