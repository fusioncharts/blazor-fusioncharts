module.exports = function(config) {
    config.set({
      frameworks: ['jest'],
      files: [
        // Add the test files and source files here
        'src/**/*.js',
        'tests/**/*.js'
      ],
      browsers: ['Chrome'],
      reporters: ['progress'],
      singleRun: true,
      // Add any other necessary configurations here
    });
  };
  