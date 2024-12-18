// src/lib/sanity.ts
import { createClient } from '@sanity/client'

export const client = createClient({
    projectId: '19eddbmg', 
    dataset: 'production',
    useCdn: true, 
    apiVersion: '2024-03-17' 
})