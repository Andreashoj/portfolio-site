<script lang="ts">
	import { onMount } from 'svelte';

	let input = '';
	let history: string[] = [];
	let commandHistory: string[] = [];
	let historyIndex = -1;
	let terminalElement: HTMLDivElement;
	let inputElement: HTMLInputElement;
	let cursorPosition = 0;
	let focused = false;
	let containerElement: HTMLDivElement;

	$: currentText = input.slice(0, cursorPosition);

	const updateCursorPosition = () => {
		if (inputElement) {
			cursorPosition = inputElement.selectionStart ?? 0;
		}
	};

	// Focus management
	const handleContainerClick = (e: MouseEvent) => {
		// If clicking inside the terminal container but not on input, focus input
		if (e.target !== inputElement) {
			inputElement?.focus();
		}
	};

	const handleFocus = () => {
		focused = true;
	};

	const handleBlur = (e: FocusEvent) => {
		// Only blur if focus is moving outside the terminal container
		if (!containerElement?.contains(e.relatedTarget as Node)) {
			focused = false;
		}
	};

	// Add automatic refocus when theme changes
	$: {
		if (typeof document !== 'undefined' && focused) {
			inputElement?.focus();
		}
	}

	const commands = {
		help: () => `Available commands:
- about - Learn about me
- skills - View my tech stack
- contact - Get my contact info
- clear - Clear the terminal
- help - Show this message`,

		about: () => `Hi, I'm Andreas! 👋
A full-stack developer specializing in Angular and Vue.js frontends with .NET backends.
Currently building scalable web applications at Universal Robots.
Type 'skills' to see my tech stack or 'projects' to explore my work.`,

		skills: () => `Technical Expertise:
- Frontend: Angular (RxJS, NgRx), Vue.js (Vuex, Pinia), TypeScript
- Styling: TailwindCSS, SCSS, Material Design
- Backend: .NET Core, C#, Entity Framework
- Testing: Jest, Cypress, xUnit
- Tools: Git, Azure, Docker
- Currently exploring: Micro-frontends & Clean Architecture`,

		contact: () => `Let's connect:
- GitHub: github.com/andrashoj
- LinkedIn: https://www.linkedin.com/in/andreas-h%C3%B8j-a9838514b/
- Email: andrewhoj@gmail.com`,

		clear: () => {
			history = [];
			return '';
		}
	};

	const processCommand = (cmd: string) => {
		const trimmedCmd = cmd.trim().toLowerCase();
		if (trimmedCmd === '') return '';

		const command = commands[trimmedCmd as keyof typeof commands];
		if (command) {
			return command();
		}

		return `Command not found: ${cmd}. Type 'help' for available commands.`;
	};

	const handleCommand = () => {
		if (input.trim() === '') return;

		const result = processCommand(input);
		history = [...history, `> ${input}`, result];
		commandHistory = [...commandHistory, input];
		historyIndex = -1;
		input = '';
		cursorPosition = 0;

		// Scroll to bottom
		setTimeout(() => {
			terminalElement.scrollTop = terminalElement.scrollHeight;
		}, 0);
	};

	const handleKeydown = (e: KeyboardEvent) => {
		if (e.key === 'Enter') {
			handleCommand();
		} else if (e.key === 'ArrowUp') {
			e.preventDefault();
			if (historyIndex < commandHistory.length - 1) {
				historyIndex++;
				input = commandHistory[commandHistory.length - 1 - historyIndex];
				// Move cursor to end of input
				setTimeout(() => {
					cursorPosition = input.length;
					inputElement.setSelectionRange(cursorPosition, cursorPosition);
				}, 0);
			}
		} else if (e.key === 'ArrowDown') {
			e.preventDefault();
			if (historyIndex > 0) {
				historyIndex--;
				input = commandHistory[commandHistory.length - 1 - historyIndex];
				// Move cursor to end of input
				setTimeout(() => {
					cursorPosition = input.length;
					inputElement.setSelectionRange(cursorPosition, cursorPosition);
				}, 0);
			} else if (historyIndex === 0) {
				historyIndex = -1;
				input = '';
				cursorPosition = 0;
			}
		}

		// Update cursor position after any key press
		setTimeout(updateCursorPosition, 0);
	};

	onMount(() => {
		history = [`Type 'help' to see available commands.`];
		inputElement?.focus();
		focused = true;
	});
</script>

<!-- svelte-ignore a11y-click-events-have-key-events -->
<!-- svelte-ignore a11y-no-noninteractive-element-interactions -->
<div
	bind:this={containerElement}
	on:click={handleContainerClick}
	class="mx-auto w-full max-w-2xl overflow-hidden rounded-lg border border-gray-200 bg-white shadow-lg transition-colors dark:border-gray-700 dark:bg-gray-900"
	role="region"
	aria-label="Interactive terminal"
>
	<!-- Terminal Header -->
	<div
		class="flex items-center border-b border-gray-200 bg-gray-100 px-4 py-2 transition-colors dark:border-gray-700 dark:bg-gray-800"
	>
		<div class="flex space-x-2">
			<div class="h-3 w-3 rounded-full bg-red-500"></div>
			<div class="h-3 w-3 rounded-full bg-yellow-500"></div>
			<div class="h-3 w-3 rounded-full bg-green-500"></div>
		</div>
		<div class="ml-4 text-sm text-gray-600 dark:text-gray-400">terminal</div>
	</div>

	<!-- Terminal Content -->
	<div
		bind:this={terminalElement}
		class="h-80 overflow-y-auto bg-white p-4 font-mono text-sm text-gray-800 transition-colors dark:bg-gray-900 dark:text-gray-300"
	>
		{#each history as line}
			<div class="mb-1 whitespace-pre-wrap">{line}</div>
		{/each}
		<div class="flex">
			<span class="text-green-600 dark:text-green-400">➜</span>
			<span class="mx-2 text-blue-600 dark:text-blue-400">~</span>
			<div class="relative flex-1">
				<!-- Hidden span to measure text width -->
				<span class="invisible absolute left-0 top-0 whitespace-pre" aria-hidden="true"
					>{currentText}</span
				>

				<input
					bind:this={inputElement}
					type="text"
					bind:value={input}
					on:keydown={handleKeydown}
					on:keyup={updateCursorPosition}
					on:click={updateCursorPosition}
					on:mousedown={updateCursorPosition}
					on:focus={handleFocus}
					on:blur={handleBlur}
					class="ml-1 w-full border-none bg-transparent text-gray-800 caret-transparent outline-none transition-colors focus:outline-none focus:ring-0 dark:text-gray-300"
					placeholder="Type 'help' for commands..."
				/>

				<div
					class={`absolute top-0 bg-gray-800 opacity-75 dark:bg-gray-400 ${
						focused ? 'animate-vim-cursor' : 'opacity-0'
					}`}
					style="left: calc(0.25rem + {currentText.length}ch); width: 1ch; height: 100%;"
				></div>
			</div>
		</div>
	</div>
</div>

<style>
	/* Hide scrollbar but keep functionality */
	div::-webkit-scrollbar {
		display: none;
	}
	div {
		-ms-overflow-style: none;
		scrollbar-width: none;
	}

	/* Vim cursor animation */
	@keyframes blink {
		0%,
		50% {
			opacity: 1;
		}
		51%,
		100% {
			opacity: 0;
		}
	}

	:global(.animate-vim-cursor) {
		animation: blink 1s steps(1) infinite;
	}

	/* Hide default cursor */
	input {
		caret-color: transparent;
	}
</style>
