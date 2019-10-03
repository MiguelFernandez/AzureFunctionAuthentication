(function () {

window.config = {
    clientId: '6b44cc8d-6e15-4bda-9b75-71e12a9143c3',
    popUp: true,
    callback: callbackFunction
};

var authContext = new AuthenticationContext(config);

function callbackFunction(errorDesc, token, error, tokenType) {
}

var user = authenticationContext.getCachedUser();
if (user) {
    // Use the logged in user information to call your own api
    onLogin(null, user);
}
else {
    // Initiate login
    authenticationContext.login();
}


authenticationContext.acquireToken(webApiConfig.resourceId, function (errorDesc, token, error) {
    if (error) { //acquire token failure
        if (config.popUp) {
            // If using popup flows
            authenticationContext.acquireTokenPopup(webApiConfig.resourceId, null, null, function (errorDesc, token, error) { });
        }
        else {
            // In this case the callback passed in the Authentication request constructor will be called.
            authenticationContext.acquireTokenRedirect(webApiConfig.resourceId, null, null);
        }
    }
    else {
        //acquired token successfully
    }
});



    }());