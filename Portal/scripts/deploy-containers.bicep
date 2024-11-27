param location string = resourceGroup().location
param acrName string
param acrUsername string
@secure()
param acrPassword string
param containerAppEnvironmentName string
param containerAppNameDotnet string
param containerAppNameBlazor string
param containerAppNameKeycloak string


resource containerAppEnv 'Microsoft.App/managedEnvironments@2023-11-02-preview' = {
  name: containerAppEnvironmentName
  location: location 
  properties: {
  }
  tags: {
    environment: 'dev'
  }
}

resource containerAppDotnet 'Microsoft.App/containerApps@2023-05-01' = {
  name: containerAppNameDotnet
  location: location
  properties: {
    environmentId: containerAppEnv.id
    configuration: {
      secrets: [
        {
          name: 'registry-password'
          value: acrPassword
        }
      ]
      registries: [
        {
          passwordSecretRef: 'registry-password'
          server: acrName
          username: acrUsername
        }
      ]
      ingress: {
        isPublic: true
        targetPort: 8080
      }
    }
    template: {
      containers: [
        {
          name: containerAppNameDotnet
          image: '${acrName}/${containerAppNameDotnet}:latest'
          resources: {
            cpu: json('0.5')
            memory: '1Gi'
          }
        }
      ]
    }
  }
}

resource containerAppBlazor 'Microsoft.App/containerApps@2023-05-01' = {
  name: containerAppNameBlazor
  location: location
  properties: {
    environmentId: containerAppEnv.id
    configuration: {
      secrets: [
        {
          name: 'registry-password'
          value: acrPassword
        }
      ]
      registries: [
        {
          passwordSecretRef: 'registry-password'
          server: acrName
          username: acrUsername
        }
      ]
      ingress: {
        external: true
        targetPort: 8080
      }
    }
    template: {
      containers: [
        {
          name: containerAppNameBlazor
          image: '${acrName}/${containerAppNameBlazor}:latest'
          resources: {
            cpu: json('0.5')
            memory: '1Gi'
          }
        }
      ]
    }
  }
}

resource containerAppKeycloak 'Microsoft.App/containerApps@2023-05-01' = {
  name: containerAppNameKeycloak
  location: location
  properties: {
    environmentId: containerAppEnv.id
    configuration: {
      secrets: [
        {
          name: 'registry-password'
          value: acrPassword
        }
      ]
      registries: [
        {
          passwordSecretRef: 'registry-password'
          server: acrName
          username: acrUsername
        }
      ]
      ingress: {
        external: true
        targetPort: 8080
      }
    }
    template: {
      containers: [
        {
          env: [
            {
              name: 'KEYCLOAK_ADMIN'
              value: 'novanet'
            }
            {
              name: 'KEYCLOAK_ADMIN_PASSWORD'
              value: 'bytt_meg'
            }
            {
              name: 'KC_HOSTNAME_STRICT'
              value: 'false'
            }
            {
                name: 'KC_HTTPS_PORT'
                value: '443'
            }
            {
                name: 'KC_Proxy'
                value: 'edge'
            }
            {
                name: 'PROXY_ADDRESS_FORWARDING'
                value: 'true'
            }
          ]
          name: containerAppNameKeycloak
          image: '${acrName}/${containerAppNameKeycloak}:latest'
          resources: {
            cpu: json('0.5')
            memory: '1Gi'
          }
        }
      ]
    }
  }
}
