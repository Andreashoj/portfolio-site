import { readable } from 'svelte/store';

export const createMediaQuery = (query: string) => {
	return readable(false, (set) => {
		if (typeof window === 'undefined') return;

		const mq = window.matchMedia(query);
		set(mq.matches);

		const listener = (e: MediaQueryListEvent) => set(e.matches);
		mq.addEventListener('change', listener);

		return () => mq.removeEventListener('change', listener);
	});
};

export const isDesktop = createMediaQuery('(min-width: 1024px)');
export const isTablet = createMediaQuery('(min-width: 768px) and (max-width: 1023px)');
export const isMobile = createMediaQuery('(max-width: 767px)');
