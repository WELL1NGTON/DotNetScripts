#!/usr/bin/env dotnet-script

#nullable enable

using System.Text;

// get argument as file path
var filePath = Args[0];

// read file
var bytes = File.ReadAllBytes(filePath);

// convert to base64
var base64 = Convert.ToBase64String(bytes);

// write to console
WriteLine(base64);
