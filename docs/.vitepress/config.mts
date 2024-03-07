import { defineConfig } from 'vitepress'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  ignoreDeadLinks: true,
  base: '/tye2/',
  title: "Tye 2",
  description: "Tye 2",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },      
      { text: 'Schema', link: '/reference/schema' },
      { text: 'CommandLine', link: '/commandline/tye' },
      { text: 'Tutorials', link: '/tutorials/01_deploy' },
      { text: 'Recipes', link: '/recipes/azure_functions' },
      { text: 'Reference', link: '/reference/deployment' }
    ],

    sidebar: [
      {
        text: 'CommandLine',
        items: [
          { text: 'Tye', link: '/commandline/tye' },
          { text: 'Tye build', link: '/commandline/tye-build' },    
          { text: 'Tye deploy', link: '/commandline/tye-deploy' },
          { text: 'Tye init', link: '/commandline/tye-init' },          
          { text: 'Tye push', link: '/commandline/tye-push' },
          { text: 'Tye run', link: '/commandline/tye-run' },
          { text: 'Tye undeploy', link: '/commandline/tye-undeploy' },
        ]
      },      
      {
        text: 'Tutorials',
        items: [
          { text: 'Run locally', link: '/tutorials/00_run_locally' },
          { text: 'Deploy', link: '/tutorials/01_deploy' },
          { text: 'Add Redis', link: '/tutorials/02_add_redis' }
        ]
      },      
      {
        text: 'Recipes',
        items: [
          { text: 'Azure functions', link: '/recipes/azure_functions' },    
          { text: 'Dapr', link: '/recipes/dapr' },
          { text: 'Distributed Tracing', link: '/recipes/distributed_tracing' },
          { text: 'Githu Actions AKS', link: '/recipes/githubactions_aks' },
          { text: 'Ingress', link: '/recipes/ingress' },
          { text: 'Logging Elastic', link: '/recipes/logging_elastic' },
          { text: 'Probes', link: '/recipes/probes' },
          
        ]
      },
      {
        text: 'Reference',
        items: [
          { text: 'Deployment', link: '/reference/deployment' },    
          { text: 'Local Development', link: '/reference/local_development' },
          { text: 'Multirepo', link: '/reference/multirepo' },
          { text: 'Schema', link: '/reference/schema' },
          { text: 'Service discovery', link: '/reference/service_discovery' }                    
        ]
      }
    ],

    socialLinks: [
      { icon: 'github', link: 'https://github.com/vuejs/vitepress' }
    ]
  }
})
