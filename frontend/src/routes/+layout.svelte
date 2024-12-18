<script lang="ts">
	import '../app.css';
    import Header from "$components/layout/Header.svelte";
    import Footer from "$components/layout/Footer.svelte";
	let { children } = $props();
</script>

<Header />
{@render children()}
<Footer />