[Home](../README.md)

![Logo](../../Docs/Images/logo.png)

# Smart Restaurant - Local development environment

Smart Restaurant is a multi-application projects based on a backend system implemented on top of Dotnet core framework and serveral frontend modules (web and mobile)

The aim of this repository is to list everything needed for a developer so that he can contribute to the development of the solution.

Estimated completion time : 30min ~ 1h

## Overview

![local-dev-overview](images/local-dev-env.png)

## Requirements

### Online software and accounts

In order to work on this project, you need to create a personal account on the following platforms

- [Gitlab account](https://gitlab.com/)
- [Teams account](https://teams.microsoft.com/)


> GitLab and most of open sources tools use Gravatar as avatar provider linked to your email address.
> Visite https://wwww.gravatar.com if you want to upload a picture for your account.

### Software

Smart Restaurant need as minimal soflware playground the following software :

- Git

You will also need :

- Dotnet core SDK 2.2 (https://dotnet.microsoft.com/download/visual-studio-sdks)

## Development profils

We provide playground for 2 kinds of developer profils :

- Web developer mode
 
In this mode, the backend system is run by the developer thanks its prefered IDE. It needs Dotnet Core SDK available.

- Mobile developer mode 

In this mode, the mobile application needs to have mobile SDKs installed

## Install

1. [Git client](#git-client)
2. [Dotnet core SDK 2.2](#dotnet-core-sdk-22)
3. [IDE](#ide)

### Git client

#### Windows

Download and install Git client from https://git-scm.com/downloads according to your OS kind.

During installation steps, accepte default proposed options.

#### GIT Post install steps

Setup your email and username by running the following command

```bash
git config --global user.email "you@example.com"
git config --global user.name "Your Name"
```

#### Enable SSH protocole for git

If you choose to use ssh protocole to checkout projects, you have to first generate your private ssh key pair if you never did it before.

Run the following command :

```bash
ssh-keygen
```

Accept default answers. This command will display where your ssh key pair has been generated. 

Usually, under the *[USER_HOME]\\.ssh\\* folder.

And setup your public ssh key at your GitLab account settings level, under the **SSH Keys** section : https://gitlab.com/profile/keys


### Dotnet core SDK 2.2

- Windows

Download and install Dotnet Core 2.2 LTS SDK framework from https://dotnet.microsoft.com/download/dotnet-core/2.2

[download 2.2.109 x64](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.109-windows-x64-installer)

### IDE

#### **VS Code** for *Front-End* and *Back-End* profil

Download and install Visual Studio Code from https://code.visualstudio.com/

Once done, test your installation with the command :

```cmd
code .
```

VS Code should starts

##### Shared setting ( not yet ready )

??????????????????? not yet ready

- code formatting
- encoding

##### recommended VSCode extenstion

- markdown-all-in-one

Completion, template for markdown language

- markdown-preview-enhanced

Press CTRL + k v

and get your markdown preview

- markdownlint

This extension will help you to write clean readme documentation

#### **Visual Studio** for *Back-End* modules profil

To Be Done ...