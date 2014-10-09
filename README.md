# GitHub Flavoured Markdown Converter #

**GitHub Flavoured Markdown Converter (GFM Converter)** converts GitHub Flavoured Markdown (GFM) to HTML using GitHub API.


## Getting Started ##

> **GFM Converter** uses [GitHub API](https://developer.github.com/v3), especially the one, [/markdown](https://developer.github.com/v3/markdown). Therefore, this **MUST** be connected to the Internet for use.


### Configuration ###

```csharp
<configSections>
    <section name="gitHubClientSettings"
             type="Aliencube.GitHub.Markdown.Configurations.GitHubClientSettings, Aliencube.GitHub.Markdown.Configurations"
             requirePermission="false" />
</configSections>

<gitHubClientSettings>
    <proxy useProxy="false" useDefaultCredentials="true" url="http://proxy:8080" domain="" username="" password="" />
    <productInformation name="GitHubMarkdownConverter" />
</gitHubClientSettings>
```

* `proxy.useProxy`: Identifies whether to use a proxy server or not. Default value is `false`.
* `proxy.useDefaultCredentials`: Itentifies whether to use default credentials or not. Default value is `true`. This will be ignored if `proxy.useProxy` is set to `false`.
* `proxy.url`: Proxy server URL. This will be ignored if `proxy.useProxy` is set to `false` or `proxy.useDefaultCredentials` is set to `true`.
* `proxy.domain`: Network domain. This will be ignored if `proxy.useProxy` is set to `false` or `proxy.useDefaultCredentials` is set to `true`.
* `proxy.username`: Username. This will be ignored if `proxy.useProxy` is set to `false` or `proxy.useDefaultCredentials` is set to `true`.
* `proxy.password`: Password. This will be ignored if `proxy.useProxy` is set to `false` or `proxy.useDefaultCredentials` is set to `true`.
* `productInformation.name`: The application name to be sent to GitHub API.


### Converter ###

```csharp
var settings = GitHubClientSettings.CreateInstance();
var helper = new Services.GitHubClientHelper(settings);
var converter = new ConverterService(helper);

var markdown = "**Hello World**";
var result = await this._converter.ConvertAsync(markdown);

// result will be "<p><strong>Hello World</strong></p>"
```


## Demo Application ##

**GFM Converter** provides a simple WPF application as a demo. Please feel free to play it with your own risk.


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work, please send us a pull request onto our `dev` branch for review.


## License ##

**GFM Converter** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2014 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
> 