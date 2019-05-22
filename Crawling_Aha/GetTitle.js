
var url = "https://www.a-ha.io/login?next=%2F";
var id = "minerva_fa@naver.com";
var pw = "tpdlzh3108";

var casper = require('casper').create({verbose: true, logLevel: "debug"});

casper.start();

casper.open(url);

/*
casper.then(function(){
    casper.fill("btn btn-fit btn-edged btn-primary", {
        email: id,
        password: pw
    }, true);
});
*/

casper.then(function(){
    casper.$('btn.btn-fit.btn-edged.btn-primary').click();
});

casper.then(function(){
    casper.capture("screenshot.png");
});

casper.run();