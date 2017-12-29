var pageUrl = "Handle/CameraControlHandle.ashx";

/*Ajax调用方法*/
/*data是需要传的json数据 fn匿名函数fn1匿名函数*/
function getAjax_far_near(data, fn, fn1) {
   
    $.ajax({
        url: pageUrl,
        type: "post",
        data:data,
        async: false,       
        dataType: "json",        
        success: fn,
        error: fn1
    });
}



function getAjax(codetype, comType, datalength, fn, fn1) {
    var data = {
        func: 'SendCodeToCamera',
        codetype: codetype,
        datalength: datalength,
        comType: comType
    }
    $.ajax({
        url: pageUrl,
        type: "post",
        data: data,
        async: false,
        dataType: "json",
        success: fn,
        error: fn1
    });
}