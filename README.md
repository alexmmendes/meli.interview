# Documentação da Arquitetura da Solução  Meli.Interview.Solution

## Visão Geral do Projeto

- O projeto tem como objetivo desenvolver uma solução que processe pedidos e determine qual centro de distribuição (CD) deve ser utilizado para enviar cada item com base nas informações fornecidas pela API de centros de distribuição. A solução deve ser capaz de lidar com até 100 itens por pedido e fornecer APIs para processar pedidos e consultar pedidos com seus CDs associados.

## Requisitos Funcionais

- Processar pedidos e determinar o CD para cada item.
- Fornecer uma API para processar pedidos e retornar os CDs associados para cada item.
- Fornecer uma API para consultar pedidos e retornar os itens e CDs associados.
- Utilizar a API "Consulta de CDs por Ítem" para auxiliar na determinação do CD para um item.
- Requisitos Não Funcionais

- Escolher uma linguagem de programação preferida.
- Escolher qualquer infraestrutura/ferramenta/framework de preferência.
- Não é necessário desenvolvimento frontend.

## Ficha Técnica

- .NET 8
- SQL Server
- Domain-Driven Design (DDD)
- Inversão de Controle (IoC)
- UnitOfWork
- Arquitetura BFF (Backend For Frontend)
- API de centros de distribuição
- API de compras (Express)

## Introdução

A API Meli.Interview.BFF serve como um ponto de unificação para as funcionalidades das APIs `Meli.Interview.Express` e `Meli.Interview.DistroCenter`. Ela fornece uma interface simplificada para operações de produtos, pedidos e centros de distribuição, otimizando a interação para aplicações frontend.

## Descrição da Arquitetura

### 1. Camada de Apresentação (Frontend)
   - Aplicações Web ou Mobile que consomem a API `Meli.Interview.BFF`.

### 2. Backend for Frontends (BFF) - `Meli.Interview.BFF`
   - **Tecnologia**: .NET 8
   - **Função**: Unifica as funcionalidades das APIs `Express` e `DistroCenter`.
   - **Principais Rotas**:
     - `/api/bff/produto` (GET, POST)
     - `/api/bff/pedido` (POST)
     - `/api/bff/centro-distribuicao/proximo-item` (GET)
     - `/api/bff/centro-distribuicao/por-item/{itemId}` (GET)

### 3. Microserviços

#### a. API de Produtos e Pedidos - `Meli.Interview.Express`
   - **Tecnologia**: .NET 8
   - **Função**: Gerencia operações de produtos e pedidos.
   - **Principais Rotas**:
     - `/api/produto` (GET, POST)
     - `/api/pedido` (POST)

#### b. API de Centros de Distribuição - `Meli.Interview.DistroCenter`
   - **Tecnologia**: .NET 8
   - **Função**: Gerencia informações sobre centros de distribuição.
   - **Principais Rotas**:
     - `/api/CentroDistribuicao/GetCentroDistribuicaoProximoItem` (GET)
     - `/api/CentroDistribuicao/GetCentroDeDistribuicao` (GET)
     - `/api/CentroDistribuicao/GetDistrosCenterByItemCDAsync/{itemId}` (GET)
     - `/api/CentroDistribuicao/GetDistrosCenterByCodigoCD/{IdCD}` (GET)
   - **Integração com Google Maps**:
     - **Objetivo**: Determinar o centro de distribuição mais próximo com base na localização.
     - **Comunicação**: A API `Meli.Interview.DistroCenter` faz chamadas para a API do Google Maps para calcular distâncias e determinar o centro mais próximo.

### 4. Serviços Externos

   - **Google Maps API**
     - **Função**: Fornece serviços de geolocalização e cálculo de distâncias.
     - **Integração**: Utilizada pela API `Meli.Interview.DistroCenter` para determinar a proximidade dos centros de distribuição.
