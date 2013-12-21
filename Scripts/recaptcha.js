var RecaptchaOptions = {
    theme : 'red',
    lang : 'sv',
    tabindex : 0
};

var RecaptchaState = {
    site: '6LcxEewSAAAAAHya_cAn72C_GgEi5B4N8mCacxMl',
    rtl: false,
    challenge: '03AHJ_VutH7ClJCPy5vjoguNEKFhyysiGGuD4-Pu2aPJv3EjwxfXgSPh6QedrF0K4WoDcS8qhJKn2nsQTK-QlFS525aeVAKZAwk-vpxmgnyWo81vBb2xrcbd6qVtm36jvqb3kdPaDGdfEVqCvqyqkPUjm-57mrtvQF55zojiL5Pr2tP3S5Sw1wMmw',
    is_incorrect: false,
    programming_error: '',
    error_message: '',
    server: 'http://www.google.com/recaptcha/api/',
    lang: 'sv',
    timeout: 1800
};

document.writeln('<scr' + 'ipt type="text/javascript" s' + 'rc="' + RecaptchaState.server + 'js/recaptcha.js"></scr' + 'ipt>');