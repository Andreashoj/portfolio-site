import { token } from '$lib/stores/auth';
import { get } from 'svelte/store';

const PUBLIC_API_KEY = import.meta.env.VITE_PUBLIC_API_KEY;

const createApiClient = (apiKey: string) => {
	const fetchWithConfig = (endpoint: string, options: RequestInit = {}) => {
		const currentToken = get(token);
		return fetch(`/api${endpoint}`, {
			...options,
			headers: {
				'X-Api-Key': apiKey,
				'Content-Type': 'application/json',
				Authorization: currentToken ? `Bearer ${currentToken}` : '',
				...options.headers
			}
		});
	};

	return {
		get: (endpoint: string) => fetchWithConfig(endpoint),
		post: (endpoint: string, data: any) =>
			fetchWithConfig(endpoint, {
				method: 'POST',
				body: JSON.stringify(data)
			}),
		patch: (endpoint: string) =>
			fetchWithConfig(endpoint, {
				method: 'PATCH'
			}),
		delete: (endpoint: string) =>
			fetchWithConfig(endpoint, {
				method: 'DELETE'
			})
	};
};

export const api = createApiClient(PUBLIC_API_KEY);
