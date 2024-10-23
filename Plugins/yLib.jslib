mergeInto(LibraryManager.library,{
    SaveData: function(data)
    {
        
        var dataString = UTF8ToString(data);
    
        var myObj = JSON.parse(dataString);
        player.setData(myObj);
    },
    LoadData: function()
    {
        player.getData().then(_data =>{
            
            const myJSON = JSON.stringify(_data);          
            myGameInstance.SendMessage('ScriptHolder','Load',myJSON);
            
                   
            })
    },
    GetLanguage : function(){
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;

    },
    ShowAdv: function(){
        
        showAdv();
    },
    Auth:  function() {

        auth();
            
            
    },
    GameIsReady: function()
    {
        gameIsReady();
    },
    AuthCheck: function()
    {
        if (player.getMode() === 'lite') {
            // Игрок не авторизован.
            return false;
        }
        else { return true; }
    },


});