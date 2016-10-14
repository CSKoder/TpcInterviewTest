/*
The test is already set up. Just look in hello.js and make the test pass. 
*/
require('chai').should();
var assert = require('assert');
var app = require('./hello.js');

describe('Hello', function () {
  it('should return hello', function () {
    // write a test to check if hello.js returns the string 'hello'
    assert.equal('hello', app._tests.hello())
  });
});
