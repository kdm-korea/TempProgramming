var puppeteer = require('puppeteer');

(async () => {

    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    const aha_id = 'github id';
    const aha_pw = 'github password';

    //페이지로 가라
    await page.goto('https://github.com/login');

    await page.evaluate((id, pw) => {
        document.querySelector('input[name="login"]').value = id;
        document.querySelector('input[name="password"]').value = pw;
        }, aha_id, aha_pw);

    await page.click('input[name="commit"]');
   
    //로그인 화면이 전환될 때까지 .5초만 기다려라
    await page.waitFor(500);

    //브라우저 꺼라
    await browser.close();
})();