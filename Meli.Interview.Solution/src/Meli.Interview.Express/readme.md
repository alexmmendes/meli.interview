# Documentação da API Meli.Interview.Express

## Introdução

A API Meli.Interview.Express oferece funcionalidades para gerenciar produtos e pedidos. Esta documentação descreve as rotas disponíveis nos controladores `ProdutoController` e `PedidoController`, permitindo operações de CRUD (Create, Read, Update, Delete) em produtos e o processamento e consulta de pedidos.

## Endpoints

### ProdutoController

#### 1. Cadastrar Produto

- **Descrição**: Cadastra um novo produto.
- **Método HTTP**: `POST`
- **Rota**: `/api/produto`
- **Corpo da Requisição**: 
  - Tipo: `ProdutoDTO`
  - Exemplo:
    ```json
    {
      "nome": "Produto Exemplo",
      "preco": 100.0,
      "descricao": "Descrição do produto exemplo"
    }
    ```
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Produto` criado.

#### 2. Consultar Produtos

- **Descrição**: Retorna uma lista de todos os produtos cadastrados.
- **Método HTTP**: `GET`
- **Rota**: `/api/produto`
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `Produto`.

#### 3. Consultar Produto por ID

- **Descrição**: Retorna os detalhes de um produto específico.
- **Método HTTP**: `GET`
- **Rota**: `/api/produto/{id}`
  - `{id}`: ID do produto a ser consultado.
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Produto` correspondente ao ID fornecido.

#### 4. Atualizar Produto

- **Descrição**: Atualiza as informações de um produto existente.
- **Método HTTP**: `PUT`
- **Rota**: `/api/produto/{id}`
  - `{id}`: ID do produto a ser atualizado.
- **Corpo da Requisição**:
  - Tipo: `ProdutoDTO`
  - Exemplo:
    ```json
    {
      "nome": "Produto Atualizado",
      "preco": 150.0,
      "descricao": "Descrição atualizada do produto"
    }
    ```
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Produto` atualizado.

#### 5. Deletar Produto

- **Descrição**: Remove um produto do sistema.
- **Método HTTP**: `DELETE`
- **Rota**: `/api/produto/{id}`
  - `{id}`: ID do produto a ser deletado.
- **Resposta**:
  - Código: `204 No Content`

### PedidoController

#### 1. Processar Pedido

- **Descrição**: Processa um novo pedido.
- **Método HTTP**: `POST`
- **Rota**: `/api/pedido`
- **Corpo da Requisição**: 
  - Tipo: `PedidoDTO`
  - Exemplo:
    ```json
    {
      "clienteId": 1,
      "produtos": [
        {
          "produtoId": 101,
          "quantidade": 2
        },
        {
          "produtoId": 102,
          "quantidade": 1
        }
      ],
      "enderecoEntrega": "Rua Exemplo, 123, Cidade, Estado"
    }
    ```
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Objeto `Pedido` processado.

#### 2. Consultar Pedidos

- **Descrição**: Retorna uma lista de todos os pedidos processados.
- **Método HTTP**: `GET`
- **Rota**: `/api/pedido`
- **Resposta**:
  - Código: `200 OK`
  - Corpo: Lista de objetos `Pedido`.

## Modelos de Dados

### ProdutoDTO

- `nome`: string
- `preco`: decimal
- `descricao`: string

### Produto

- `id`: int
- `nome`: string
- `preco`: decimal
- `descricao`: string

### PedidoDTO

- `clienteId`: int
- `produtos`: lista de objetos contendo:
  - `produtoId`: int
  - `quantidade`: int
- `enderecoEntrega`: string

### Pedido

- `id`: int
- `clienteId`: int
- `produtos`: lista de objetos contendo:
  - `produtoId`: int
  - `quantidade`: int
- `enderecoEntrega`: string
- `dataPedido`: datetime

## Observações
- Todos os endpoints são protegidos e requerem autenticação apropriada (detalhes sobre autenticação não estão incluídos).