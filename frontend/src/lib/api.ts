const PUBLIC_API_KEY = import.meta.env.VITE_PUBLIC_API_KEY;

const createApiClient = (apiKey: string) => {
	const fetchWithConfig = (endpoint: string, options: RequestInit = {}) => {
		return fetch(`/api${endpoint}`, {
			...options,
			headers: {
				'X-Api-Key': apiKey,
				'Content-Type': 'application/json',
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
