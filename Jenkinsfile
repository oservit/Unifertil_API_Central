pipeline {
    // Define para rodar no seu agente específico.
    agent {
        label 'ol8-agent'
    }

    // Variáveis de ambiente para o nosso projeto.
    environment {
        IMAGE_NAME     = "unifertil-api-central"
        IMAGE_TAG      = "build-${env.BUILD_NUMBER}" 
        CONTAINER_NAME = "unifertil-api-central"
    }

    stages {
        stage('Checkout') {
            steps {

                sh 'ls -R'
                
                echo 'Baixando o código do repositório...'
                // Garante que o workspace esteja limpo antes de começar
                cleanWs() 
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                echo "Construindo a imagem ${env.IMAGE_NAME}:${env.IMAGE_TAG}..."
                sh "docker build -t ${env.IMAGE_NAME}:${env.IMAGE_TAG} ."
            }
        }

        stage('Stop and Remove Old Container') {
            steps {
                echo "Parando e removendo o contêiner antigo, se existir..."
                sh "docker stop ${env.CONTAINER_NAME} || true"
                sh "docker rm ${env.CONTAINER_NAME} || true"
            }
        }

        stage('Run New Container') {
            steps {
                echo "Iniciando o novo contêiner..."
                sh "docker run -d --name ${env.CONTAINER_NAME} -p 5010:5010 --restart always ${env.IMAGE_NAME}:${env.IMAGE_TAG}"
            }
        }
    }

    post {
        always {
            echo 'Limpando o workspace do Jenkins.'
            cleanWs()
        }
        success {
            echo 'Pipeline executado com sucesso!'
            sh 'docker image prune -a -f'
        }
        failure {
            echo 'O pipeline falhou.'
        }
    }
}