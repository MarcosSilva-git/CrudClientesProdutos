# CrudClientesProdutos

Este projeto é uma aplicação web que integra uma API desenvolvida em ASP.NET Core com um frontend em Angular. A aplicação permite gerenciar clientes e produtos, oferecendo funcionalidades de CRUD (Create, Read, Update, Delete) para ambos os módulos.

## Estrutura do Projeto

A solução está organizada nos seguintes diretórios:

- **CrudClientesProdutos.Application**: Contém a lógica de aplicação, incluindo casos de uso e serviços.
- **CrudClientesProdutos.Client**: Abriga a interface do usuário desenvolvida em Angular.
- **CrudClientesProdutos.Domain**: Define as entidades de domínio e interfaces.
- **CrudClientesProdutos.Infrastructure**: Implementa detalhes de infraestrutura, como acesso a dados e serviços externos.
- **CrudClientesProdutos.Server**: Contém a API desenvolvida em ASP.NET Core.
- **CrudClientesProdutos.UnitTests**: Inclui testes unitários para garantir a qualidade do código.

## Pré-requisitos

Antes de executar a aplicação, certifique-se de que os seguintes componentes estão instalados em seu sistema:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (que inclui o npm)
- [Angular CLI](https://angular.io/cli)

### Instalando o .NET SDK

Para instalar o .NET SDK, siga as instruções específicas para o seu sistema operacional:

- **Windows**:
  1. Acesse a [página de download do .NET](https://dotnet.microsoft.com/download).
  2. Baixe o instalador para Windows.
  3. Execute o instalador e siga as instruções na tela.

- **macOS**:
  1. Acesse a [página de download do .NET](https://dotnet.microsoft.com/download).
  2. Baixe o instalador para macOS.
  3. Execute o instalador e siga as instruções na tela.

- **Linux**:
  1. Acesse a [documentação oficial do .NET para Linux](https://learn.microsoft.com/en-us/dotnet/core/install/linux).
  2. Siga as instruções específicas para a sua distribuição Linux.

Após a instalação, verifique se o .NET CLI está disponível executando:

```bash
dotnet --version
```

### Instalando o Angular CLI

O Angular CLI é necessário para gerenciar o frontend da aplicação. Para instalá-lo globalmente, execute:

```bash
npm install -g @angular/cli
```

Verifique a instalação com:

```bash
ng version
```

## Configuração do Projeto

Siga os passos abaixo para configurar e executar a aplicação:

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/MarcosSilva-git/CrudClientesProdutos.git
   cd CrudClientesProdutos
   ```

2. **Restaure as dependências do .NET**:

   ```bash
   dotnet restore
   ```

3. **Instale as dependências do Angular**:

   Navegue até o diretório do cliente Angular e instale as dependências:

   ```bash
   cd CrudClientesProdutos.Client
   npm install
   ```

4. **Compile a aplicação Angular**:

   Ainda no diretório `CrudClientesProdutos.Client`, execute:

   ```bash
   ng build
   ```

   Isso gerará os arquivos estáticos do Angular no diretório `dist/`.

5. **Execute a API ASP.NET Core**:

   Navegue de volta para o diretório raiz do projeto e execute:

   ```bash
   cd ..
   dotnet run --project .\CrudClientesProdutos.Server\CrudClientesProdutos.Server.csproj
   ```

   Isso iniciará a API e servirá os arquivos do frontend Angular. Por padrão, a aplicação estará disponível em `https://localhost:5001/`.

## Executando Testes

Para executar os testes unitários, utilize o comando:

```bash
dotnet test
```

Isso executará todos os testes presentes no projeto `CrudClientesProdutos.UnitTests`.
