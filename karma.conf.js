// Karma configuration
// Generated on Tue Sep 03 2013 13:12:45 GMT+0200 (W. Europe Daylight Time)

module.exports = function(config) {
  config.set({

    // base path, that will be used to resolve files and exclude
    basePath: '',


    // frameworks to use
    frameworks: ['jasmine'],


    // list of files / patterns to load in the browser
    files: [

       // The Components
      './src/**/Scripts/jquery-2.0.3.js',
      './src/**/Scripts/angular.js',
      './src/**/Scripts/angular-mocks.js',
      './src/**/Scripts/angular-route.js',
      './src/**/Scripts/angular-resource.js',
      './src/**/Scripts/angular-sanitize.js',
      './src/**/Scripts/angular-animate.js',
      './src/**/Scripts/ngMidwayTester.js',
      './src/**/BackOfficeApp/js/*.js',
      './src/**/BackOfficeApp/App.js',

      // the Specs
      './src/**/specs/**/*.js'
    ],


    // list of files to exclude
    exclude: [
      
    ],


    // test results reporter to use
    // possible values: 'dots', 'progress', 'junit', 'growl', 'coverage'
    reporters: ['progress'],


    // web server port
    port: 9876,


    // enable / disable colors in the output (reporters and logs)
    colors: true,


    // level of logging
    // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
    logLevel: config.LOG_INFO,


    // enable / disable watching file and executing tests whenever any file changes
    autoWatch: true,


    // Start these browsers, currently available:
    // - Chrome
    // - ChromeCanary
    // - Firefox
    // - Opera
    // - Safari (only Mac)
    // - PhantomJS
    // - IE (only Windows)
    browsers: ['Chrome','Firefox', 'PhantomJS'],


    // If browser does not capture in given timeout [ms], kill it
    captureTimeout: 60000,


    // Continuous Integration mode
    // if true, it capture browsers, run tests and exit
    singleRun: false
  });
};
