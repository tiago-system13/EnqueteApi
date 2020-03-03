# EnqueteApi
Uma enquete é uma pesquisa, na qual as pessoas respondem uma pergunta escolhendo dentre algumas alternativas pré-definidas.
O	seu	objetivo	é	criar	uma	API	RESTful	para	a	utilização	de	uma	enquete

Manual de montagem de ambiente de desenvolvimento.

## Conteúdo

-[Pré-requisitos](#pré-requisitos)
- [Configuração](#configuração)
- [Execução](#execução)
- [LaunchSettings](#launchSettings)
- [Environment Variables](#environment)
- [Connection Strings](#connection-strings)

**Atenção**

> Todos os passos desta documentação são obrigatórios, sendo imprescindível que você obtenha sucesso na realização de cada passo.

> Nesta documentação considero que você está utilizando o SO Windows 10. Caso esteja utilizando outro sistema operacional, faça as devidas adaptações.

## Pré-requisitos

É necessário que você tenha instalado em sua máquina:

- [.Net Core](https://dotnet.microsoft.com/download) (_2.2_)
  _A instalação deve anteceder os próximos passos ou pode ser feita através do visual studio installer caso opte por usar a IDE, adicionando o pacote .Net Core._

- Recomendo a IDE [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) (_2017 ou superior_) ou o editor de texto [Visual Studio Code](https://code.visualstudio.com/download)

- A instalação do banco de dados [Sql Server](https://docs.microsoft.com/pt-br/sql/getting-started/quick-start-installation-of-sql-server-2014?view=sql-server-2014) (_2014 ou superior_)

> No  projeto EnqueteApi.Data existe a pasta Script que contém os scripts de criação de database, schema e tabelas.
  > Apos concluir a instalação do Sql Server é necessário executar esses scripts na seguinte ordem:
  1. script_create_data_base.sql
  2. script_create_schema.sql
  3. script_create_table.sql

## Configuração

### Ambiente

- Enquanto o projeto estiver em ambiente de desenvolvimento os valores abaixo deverão permanecer como foram previamente configurados

- **Caso esteja utilizando o Visual Studio**

  > Clicando com o botão direito no projeto EnqueteApi e selecionando a opção propriedades, será aberto o menu de propriedades do projeto em questão, selecionando a opção depurar é possível encontrar as variáveis do ambiente.
  > Enquanto a variável `ASPNETCORE_ENVIRONMENT` estiver com o valor `Development`, o projeto irá iniciar com as configurações de desenvolvimento, caso o valor seja alterado as configurações de inicialização também sofrerão alterações. Valores possíveis para a variável são: `Development e Production`
  

## Execução

O projeto Enquete está dividido em módulos, o módulo EnqueteApi é o ponto de entrada da aplicação, os módulos EnqueteApi.Core e EnqueteApi.Data são bibliotecas de classe e o EnqueteApi.Test é o projeto que contém os testes.

**Atenção**

- **Caso esteja utilizando o Visual Studio**

> Neste momento o seu Visual Studio já deve estar configurado com o .NET Core.


1. Abra o arquivo EnqueteApi.sln_ com o Visual Studio.

3. Execute a aplicação a partir do projeto EnqueteApi, utilizando o menu que se encontra no topo da tela clicando no botão play.

> No navegador padrão da máquina será aberto uma página no endereço `https://localhost:44335/swagger/index.html`, o endpoint apresentará uma página com a documentação da Api. 

## LaunchSettings

No projeto EnqueteApi, é necessário a criação de um arquivo `launchSettings.json` na pasta `Properties` para que o projeto seja executado corretamente e tenha todas as variáveis de ambiente. Para isso basta criar a pasta Properties no projeto EnqueteApi, adicionar o arquivo launchSettings.json na pasta e colar o json abaixo.

```json
{
  "iisSettings": {
    "windowsAuthentication": false, 
    "anonymousAuthentication": true, 
    "iisExpress": {
      "applicationUrl": "http://localhost:51497",
      "sslPort": 44335
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production",
        "DATABASE_CONNECTION_STRING": "Data Source=TIAGO-INFOR13;Initial Catalog=Enquete;Integrated Security=True"
      }
    },
    "EnqueteApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production",
        "DATABASE_CONNECTION_STRING": "Data Source=TIAGO-INFOR13;Initial Catalog=Enquete;Integrated Security=True"
      }
    }
  }
}
```

## Environment

Aqui está uma tabela com todas as variáveis de ambiente existentes no projeto até o momento e que também aparecerem no `launchSettings.json` mostrado acima.

| Nome                                  | Descrição                                            | Valor de exemplo                                             |
| ------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------------ |
| **ASPNETCORE_ENVIRONMENT**            | Valores possíveis `Development e Production`		   | Development                                                  |
| **DATABASE_CONNECTION_STRING**        |                                                      | "Data Source=Servidor;Initial Catalog=Enquete;Integrated Security=True"; |

## Connection Strings

- Por padrão as connection strings que estão no projeto são para acesso ao banco de dados local da minha máquina, para testar a api utilizando o banco de dados interno
  será necessário alterar essas variáveis que se encontram no arquivo `launchSettings.json` no projeto EnqueteApi.
