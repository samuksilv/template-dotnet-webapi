# templateAPI Web API ASP.NET Core

Exemplo de um templateAPI asp.net core, estruturado com DDD. Serve como uma casca com exemplos para agilizar o inicio de um projeto novo.

Este templateAPI já vem configurado com:
-  swagger;
-  logs;
-  exemplos de testes(testes unitários, e testes de integração);
-  configurações de docker;
-  compressão do retorno da api( compressão do Json no formato .Gzip);

# Instalação

Para fazer a instalação do templateAPI na sua máquina basta usar o comando na raiz do projeto : 

```
dotnet new -i .
```

# Uso

Após a instalação será possível visualizar o templateAPI na linha de comando ao usar o comando:

```
dotnet new -h
```     

Será listado o templateAPI conforme abaixo:


![logo](dotnet-template.png)


Para utiliza-lo use o comando:

```
dotnet new samApi -n <nome api>
```

# Requisitos

Para instalar o templateAPI é preciso ter instalado o SDK do .NET Core 2.0 ou alguma versão acima.

# Referências

https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templateAPIs

https://docs.microsoft.com/pt-br/dotnet/core/tools/dotnet-new?tabs=netcore21

https://github.com/dotnet/templating/wiki/Reference-for-templateAPI.json








