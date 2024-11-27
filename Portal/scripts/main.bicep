// main.bicep

param location string = resourceGroup().location
param acrName string
// param containerAppEnvironmentName string
// param containerAppNameDotnet string
// param containerAppNameBlazor string
// param containerAppNameKeycloak string

resource acr 'Microsoft.ContainerRegistry/registries@2022-12-01' = {
  name: acrName
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

// resource containerAppEnv 'Microsoft.App/managedEnvironments@2022-03-01' = {
//   name: containerAppEnvironmentName
//   location: location
// }

// resource containerAppDotnet 'Microsoft.App/containerApps@2022-03-01' = {
//   name: containerAppNameDotnet
//   location: location
//   properties: {
//     managedEnvironmentId: containerAppEnv.id
//     configuration: {
//       registries: [
//         {
//           server: acr.properties.loginServer
//           username: acr.listCredentials().username
//           password: acr.listCredentials().passwords[0].value
//         }
//       ]
//       ingress: {
//         external: true
//         targetPort: 80
//       }
//     }
//     template: {
//       containers: [
//         {
//           name: containerAppNameDotnet
//           image: '${acr.properties.loginServer}/${containerAppNameDotnet}:latest'
//           resources: {
//             cpu: 1
//             memory: '1Gi'
//           }
//         }
//       ]
//     }
//   }
// }

// resource containerAppBlazor 'Microsoft.App/containerApps@2022-03-01' = {
//   name: containerAppNameBlazor
//   location: location
//   properties: {
//     managedEnvironmentId: containerAppEnv.id
//     configuration: {
//       registries: [
//         {
//           server: acr.properties.loginServer
//           username: acr.listCredentials().username
//           password: acr.listCredentials().passwords[0].value
//         }
//       ]
//       ingress: {
//         external: true
//         targetPort: 80
//       }
//     }
//     template: {
//       containers: [
//         {
//           name: containerAppNameBlazor
//           image: '${acr.properties.loginServer}/${containerAppNameBlazor}:latest'
//           resources: {
//             cpu: 1
//             memory: '1Gi'
//           }
//         }
//       ]
//     }
//   }
// }

// resource containerAppKeycloak 'Microsoft.App/containerApps@2022-03-01' = {
//   name: containerAppNameKeycloak
//   location: location
//   properties: {
//     managedEnvironmentId: containerAppEnv.id
//     configuration: {
//       registries: [
//         {
//           server: acr.properties.loginServer
//           username: acr.listCredentials().username
//           password: acr.listCredentials().passwords[0].value
//         }
//       ]
//       ingress: {
//         external: true
//         targetPort: 8080
//       }
//     }
//     template: {
//       containers: [
//         {
//           name: containerAppNameKeycloak
//           image: '${acr.properties.loginServer}/${containerAppNameKeycloak}:latest'
//           resources: {
//             cpu: 1
//             memory: '1Gi'
//           }
//         }
//       ]
//     }
//   }
// }
// resource keyVault 'Microsoft.KeyVault/vaults@2023-07-01' existing = {
//   name: 'kvnovanetsharedprod'
//   scope: resourceGroup('novanet-rg-shared-prod')
// }
// resource keyVaultSecret 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
//   name: 'kvnovanetsharedprod/test' 
//   properties: {
//     value: acr.listCredentials().passwords[0].value
//   }
//   scope: resourceGroup('novanet-rg-shared-prod')

// }


// module secretModule 'keyvault-secret.bicep' = {
//   name: 'secretModule'
//   scope: resourceGroup('novanet-rg-shared-prod')
//   params: {
//     keyVault: keyVault
//     acr: acr
//   }
// }
output acrLoginServer string = acr.properties.loginServer
output acrAdminUsername string = acr.listCredentials().username
output acrAdminPassword string = acr.listCredentials().passwords[0].value
