using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions; //action metodu için 
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_EmircanArslan
{
    class Program
    {
        private static WebDriverWait wait;
        private static string elementId;

        public static object ExpectedConditions { get; private set; }

        static void Main(string[] args)
        {

            IWebDriver driver = new FirefoxDriver();
            string link = @"https://www.n11.com/"; // giriş yapılacak olan site linki
            driver.Navigate().GoToUrl(link); // linkin açılması için.

            driver.FindElement(By.ClassName("btnSignIn")).Click(); // burada n11 deki giriş clasının ismini belirttik.
            driver.FindElement(By.Id("email")).SendKeys("xdp15871@bcaoo.com");// e mail kısmına değer girebilmek için sendkeys kullanırız.
            driver.FindElement(By.Id("password")).SendKeys("a123456789");
            driver.FindElement(By.Id("loginButton")).Click();// e mail ve şifre girdikten sonra giriş yapabilmesi için.

            driver.FindElement(By.Id("searchData")).SendKeys("samsung"); // site içindeki arama kısmına yazmak için 
            driver.FindElement(By.ClassName("searchBtn")).Click(); // arama kısmına yazıyı yazdıkdan sonra arama yapması için

            driver.FindElement(By.XPath(".//*[@id='contentListing']/div/div/div[2]/div[4]/a[2]")).Click(); // burada arama yaptıkdan sonra 2. sayfaya geçmesi için yazdık. "xpath" ; bütün sayfa içinde arama yapar.
            // yukarıdaki kısmı uzatmamın sebebi eğer başka bir sitede her dive bir id değeri verilmediğinde istediğimiz sayfaya ulaşmak için tek tek belirttik. 

            driver.FindElement(By.XPath("//*[@id='p-252308949']/div[2]/span[1]")).Click(); // favorilerime eklemek için. 
                                                                                           /* not : n11 de favori kısmındaki ürünün id si her gün değişiyor bunun nedenini bilmiyorum eğer burada 
                                                                                           bir hata alırsanız bu sitedeki id değerinin değişmesinden kaynaklıdır.*/

            driver.FindElement(By.XPath("//*[@id='btnScrollTop']")).Click();//sayfayı yukarı kaydırmak için

            System.Threading.Thread.Sleep(4000); // sayfa yukarı çıktık dan sonra  beklemesi için 4 sn lik bir bekleme süresi ekledim. 

            //******************  favori kısmını açmak için ******************************
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.XPath(".//*[@id='wrapper']/header[1]/div[1]/div[1]/div[2]/div[2]/div[2]")))
            .Click().Build().Perform();
            driver.FindElement(By.XPath(".//*[@id='wrapper']/header[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/a[2]")).Click();

            //*****************************************************************************************

            driver.FindElement(By.XPath("//*[@id='wrapper']/div[2]/div[1]/div[2]/div[3]/ul[1]/li[1]/div[1]/a[1]")).Click(); // fovorideki ürünü açmak için.

            driver.FindElement(By.XPath("//*[@id='wrapper']/div[2]/div[1]/div[2]/div[3]/div[1]/div[2]/ul[1]/li[1]/div[1]/div[3]/span[1]")).Click(); // sil linkine basmka için. 

            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@class='lightBox']/div[1]/div[1]/span[1]")).Click(); // silden sonra tamam a basmak için. 





        }
    }
}
