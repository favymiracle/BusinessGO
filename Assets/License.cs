// TextToTexturePackage - Demonstrating a method for apply text to a texture without using Render To Texture
// This license applies to all non default Unity assets. Ex: Custom models, custom textures, custom code, etc.
//
// released under MIT License
// http://www.opensource.org/licenses/mit-license.php
//
//@author		Devin Reimer, Calin Reimer(Models and Textures)
//@version		1.0.0
//@website 		http://blog.almostlogical.com

//Copyright (c) 2010 Devin Reimer

/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using UnityEngine;
public class License : MonoBehaviour //required file, just a clever way of adding a license to a Unity Project Package
{
    public void Awake()
    {
        Debug.Log("Devin Reimer - http://blog.almostlogical.com\nSee attached License.cs file for license details");
    }
} 
