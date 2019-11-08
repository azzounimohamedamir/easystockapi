# Backend

| Product          | Smart Restaurant         |
|------------------|:------------------------:|
| Document owner   | @medkamelbouzekria       |
| Document status  | Draft                    |
| Version          | 1.0.0                    |
| Last update      | 05 Sep 2019              |

## Overview

The Smart restaurant Backend is based on a clean architecture. This means that the business logic and application model are put at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this dependency is inverted: infrastructure and implementation details depend on the Application Core. This is achieved by defining abstractions, or interfaces, in the Application Core, which are then implemented by types defined in the Infrastructure layer.

## Application layers

So far, we have x layers :


## Dependencies managment

Nuget packages used by Smart Restaurant backend modules are defined at this place Dependencies managment