# Multiple Enumeration in C#

## Overview
This project demonstrates the concept of multiple enumeration in C# and its potential performance implications. It shows how deferred execution behaves when IEnumerable collections are enumerated more than once.

## Problem Explained
When working with LINQ and IEnumerable in C#, operations are lazily evaluated (deferred execution). This means the query isn't executed until you actually iterate over the results. If you enumerate the same IEnumerable multiple times, the entire query will be re-executed each time.

In this example:
1. We query a database for products
2. Apply sorting operations (OrderBy, ThenBy)
3. Transform the data (Select)
4. Enumerate the results twice

The console output reveals that each time we enumerate the collection, all operations (database fetch, sorting, transformation) happen again.

## Why This Matters
Multiple enumeration can lead to:
- Unnecessary database queries
- Repeated expensive operations
- Unexpected side effects
- Performance degradation

## Solution
To avoid multiple enumeration issues:
- Use `.ToList()`, `.ToArray()`, or `.ToDictionary()` when you need to enumerate a sequence multiple times
- Store the results in a variable when they will be reused
- Be mindful when working with resource-intensive operations

## Implementation
This example intentionally demonstrates the problem by using database operations, console output tracking, and two identical foreach loops to make the repeated execution visible.